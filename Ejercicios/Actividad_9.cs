using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios;

// ═══════════════════════════════════════════════════════════════════
//  CLASE Participante
//  Representa a una persona que puede asistir al evento.
//
//  ESTRATEGIA DE IGUALDAD:
//  Dos participantes se consideran la misma persona si tienen
//  el mismo Documento, O el mismo Email normalizado
//  (sin importar mayúsculas ni espacios al inicio/final).
// ═══════════════════════════════════════════════════════════════════
public class Participante : IEquatable<Participante>
{
    public Guid   Id             { get; init; } = Guid.NewGuid();
    public string Documento      { get; init; } = "";
    public string NombreCompleto { get; init; } = "";
    public string Email          { get; init; } = "";
    public bool   EsVip          { get; init; }

    // Normaliza el email: elimina espacios y convierte a minúsculas
    private string EmailNorm => Email.Trim().ToLowerInvariant();

    // Dos participantes son iguales si comparten Documento O Email normalizado
    public bool Equals(Participante? other) =>
        other is not null &&
        (Documento == other.Documento || EmailNorm == other.EmailNorm);

    public override bool Equals(object? obj) => Equals(obj as Participante);

    // Constante 0: obliga al HashSet a llamar Equals en cada inserción
    public override int GetHashCode() => 0;

    public override string ToString() =>
        $"{NombreCompleto} | DOC: {Documento} | EMAIL: {Email}";
}

// ═══════════════════════════════════════════════════════════════════
//  CLASE Taller
//  Representa un taller del evento con horario y capacidad máxima.
// ═══════════════════════════════════════════════════════════════════
public class Taller
{
    public Guid     Id         { get; init; } = Guid.NewGuid();
    public string   Nombre     { get; init; } = "";
    public TimeOnly HoraInicio { get; init; }
    public TimeOnly HoraFin    { get; init; }
    public int      Capacidad  { get; init; }
}

// ═══════════════════════════════════════════════════════════════════
//  CLASE InscripcionTaller
//  Relaciona un participante con el taller al que fue inscrito.
// ═══════════════════════════════════════════════════════════════════
public class InscripcionTaller
{
    public Participante Participante { get; init; } = null!;
    public Taller       Taller       { get; init; } = null!;
}

// ═══════════════════════════════════════════════════════════════════
//  CLASE PRINCIPAL
//  Gestiona las colecciones, la lógica de conciliación y los reportes.
// ═══════════════════════════════════════════════════════════════════
public class Conciliacion_Asistentes_Talleres
{
    // ── Fuentes de participantes (cada una es un HashSet para evitar duplicados internos)
    static HashSet<Participante>      preregistrados   = new(); // registrados desde la web
    static HashSet<Participante>      registroManual   = new(); // registrados en taquilla
    static HashSet<Participante>      invitadosVip     = new(); // invitados especiales
    static HashSet<Participante>      listaNegra       = new(); // acceso restringido
    static HashSet<Participante>      asistentesReales = new(); // quienes entraron al evento
    static HashSet<InscripcionTaller> inscripciones    = new(); // inscripciones válidas a talleres

    // ── Estructuras auxiliares
    static List<Taller>        talleres   = new(); // catálogo de talleres disponibles
    static List<string>        rechazos   = new(); // log de inscripciones rechazadas
    static List<string>        duplicados = new(); // log de duplicados detectados en carga
    static Dictionary<Taller, int> cupos  = new(); // cuántos inscritos tiene cada taller

    // ── Resultados de la conciliación (calculados en Opción 2)
    static HashSet<Participante> autorizados   = new(); // pueden ingresar al evento
    static HashSet<Participante> noAutorizados = new(); // entraron pero no debían
    static HashSet<Participante> ausentes      = new(); // autorizados que no llegaron

    // Controla que el reporte solo se muestre si ya se procesó la conciliación
    static bool conciliado = false;

    // ── Punto de entrada del ejercicio ──────────────────────────────────────
    public static void Ejecutar()
    {
        Console.Clear();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Sistema de Conciliación - BreakLine Events ===");
            Console.WriteLine("1. Cargar datos de prueba");
            Console.WriteLine("2. Procesar conciliación");
            Console.WriteLine("3. Mostrar reporte consolidado");
            Console.WriteLine("0. Volver");
            Console.Write("\nOpción: ");

            switch (Console.ReadLine())
            {
                case "1": CargarDatos();          break;
                case "2": ProcesarConciliacion(); break;
                case "3": MostrarReporte();       break;
                case "0": return;
            }
        }
    }

    // ════════════════════════════════════════════════════════════════
    //  OPCIÓN 1 — Cargar datos de prueba
    //  Inicializa todas las colecciones con datos quemados que cubren
    //  los 6 casos de prueba definidos en el enunciado.
    //
    //  Cálculo de autorizados esperados:
    //    pre(13) ∪ manual(+2 nuevos: tomas, marta) ∪ vip(+3) = 18
    //    menos negra(2: carlos, felipe) = 16 autorizados finales
    // ════════════════════════════════════════════════════════════════
    static void CargarDatos()
    {
        // Limpiar todo antes de cargar para permitir recargas limpias
        preregistrados.Clear(); registroManual.Clear(); invitadosVip.Clear();
        listaNegra.Clear(); asistentesReales.Clear(); inscripciones.Clear();
        talleres.Clear(); rechazos.Clear(); duplicados.Clear(); cupos.Clear();
        conciliado = false;

        // ── Talleres disponibles en el evento ────────────────────────────────
        // t1 y t2 se solapan en horario (9-11 y 10-12), lo que activa el Caso 5
        // t3 tiene capacidad 1, lo que activa el Caso 6
        var t1 = new Taller { Nombre = "Clean Code",              HoraInicio = new TimeOnly(9,  0), HoraFin = new TimeOnly(11, 0), Capacidad = 10 };
        var t2 = new Taller { Nombre = "Microservicios Avanzados", HoraInicio = new TimeOnly(10, 0), HoraFin = new TimeOnly(12, 0), Capacidad = 10 };
        var t3 = new Taller { Nombre = "Docker Pro",               HoraInicio = new TimeOnly(13, 0), HoraFin = new TimeOnly(15, 0), Capacidad = 1  };
        talleres.AddRange(new[] { t1, t2, t3 });

        // ── Definición de participantes ──────────────────────────────────────

        // Caso 1: duplicado por documento — mismo doc "123", diferente nombre y email
        var ana    = new Participante { Documento = "123",  NombreCompleto = "Ana Torres",    Email = "ana@gmail.com"       };
        var anaDup = new Participante { Documento = "123",  NombreCompleto = "Ana T.",         Email = "anatorres@gmail.com" };

        // Caso 2: duplicado por email normalizado — docs distintos pero email igual al normalizar
        // "LDiaz@correo.com" y "ldiaz@correo.com " son el mismo email después de Trim + ToLower
        var luis    = new Participante { Documento = "999",  NombreCompleto = "Luis Díaz",     Email = "LDiaz@correo.com"   };
        var luisDup = new Participante { Documento = "888",  NombreCompleto = "Luis D.",        Email = "ldiaz@correo.com "  };

        // Caso 3: preregistrados que también estarán en lista negra → no autorizados
        var carlos  = new Participante { Documento = "7788", NombreCompleto = "Carlos Ruiz",   Email = "carlos@correo.com"  };
        var felipe  = new Participante { Documento = "3030", NombreCompleto = "Felipe Ríos",   Email = "felipe@correo.com"  };

        // Caso 4: persona que entra al evento sin haber sido registrada en ninguna fuente
        var intruso = new Participante { Documento = "0000", NombreCompleto = "Intruso X",     Email = "intruso@x.com"      };

        // Participantes adicionales para completar los conjuntos
        var pedro   = new Participante { Documento = "5566", NombreCompleto = "Pedro Soto",    Email = "pedro@correo.com"   };
        var mario   = new Participante { Documento = "3344", NombreCompleto = "Mario Vargas",  Email = "mario@correo.com"   };
        var jorge   = new Participante { Documento = "4433", NombreCompleto = "Jorge Medina",  Email = "jorge@correo.com"   };
        var camila  = new Participante { Documento = "6655", NombreCompleto = "Camila Rojas",  Email = "camila@correo.com"  };
        var andres  = new Participante { Documento = "8877", NombreCompleto = "Andrés Castro", Email = "andres@correo.com"  };
        var valeria = new Participante { Documento = "1010", NombreCompleto = "Valeria Nieto", Email = "valeria@correo.com" };
        var daniela = new Participante { Documento = "2020", NombreCompleto = "Daniela Mora",  Email = "daniela@correo.com" };
        var isabela = new Participante { Documento = "4040", NombreCompleto = "Isabela Cruz",  Email = "isabela@correo.com" };
        var lucia   = new Participante { Documento = "9900", NombreCompleto = "Lucía Flores",  Email = "lucia@correo.com"   };
        var tomas   = new Participante { Documento = "1100", NombreCompleto = "Tomás Herrera", Email = "tomas@correo.com"   };
        var marta   = new Participante { Documento = "2200", NombreCompleto = "Marta Jiménez", Email = "marta@correo.com"   };
        var laura   = new Participante { Documento = "1122", NombreCompleto = "Laura Pérez",   Email = "laura@correo.com",   EsVip = true };
        var roberto = new Participante { Documento = "5577", NombreCompleto = "Roberto Vega",  Email = "roberto@correo.com", EsVip = true };
        var diana   = new Participante { Documento = "6688", NombreCompleto = "Diana Torres",  Email = "diana@correo.com",   EsVip = true };

        // ── Preregistrados: 15 intentos → 2 rechazados → 13 únicos ──────────
        // Agregar() llama HashSet.Add() internamente. Si el participante ya existe
        // (por doc o email), Add() retorna false y se registra el duplicado.
        Agregar(preregistrados, ana,     "preregistrados");
        Agregar(preregistrados, anaDup,  "preregistrados", esDupDoc: true,   valor: "123");              // Caso 1 → rechazado
        Agregar(preregistrados, luis,    "preregistrados");
        Agregar(preregistrados, luisDup, "preregistrados", esDupEmail: true, valor: "ldiaz@correo.com"); // Caso 2 → rechazado
        Agregar(preregistrados, carlos,  "preregistrados"); // entrará a lista negra después
        Agregar(preregistrados, felipe,  "preregistrados"); // entrará a lista negra después
        Agregar(preregistrados, pedro,   "preregistrados");
        Agregar(preregistrados, mario,   "preregistrados");
        Agregar(preregistrados, jorge,   "preregistrados");
        Agregar(preregistrados, camila,  "preregistrados");
        Agregar(preregistrados, andres,  "preregistrados");
        Agregar(preregistrados, valeria, "preregistrados");
        Agregar(preregistrados, daniela, "preregistrados");
        Agregar(preregistrados, isabela, "preregistrados");
        Agregar(preregistrados, lucia,   "preregistrados"); // también en manual → solapamiento en la unión
        // preregistrados.Count = 13 ✓

        // ── Registro manual: 4 ───────────────────────────────────────────────
        // carlos y lucia ya están en preregistrados, pero se guardan igual en
        // registroManual (son colecciones independientes). El solapamiento se
        // resuelve al calcular la unión en ProcesarConciliacion con UnionWith.
        Agregar(registroManual, carlos, "registroManual"); // solapamiento con preregistrados
        Agregar(registroManual, lucia,  "registroManual"); // solapamiento con preregistrados
        Agregar(registroManual, tomas,  "registroManual"); // participante nuevo en la unión
        Agregar(registroManual, marta,  "registroManual"); // participante nuevo en la unión
        // registroManual.Count = 4 ✓

        // ── Invitados VIP: 3 ─────────────────────────────────────────────────
        // Todos son nuevos en la unión total (no estaban en pre ni manual)
        Agregar(invitadosVip, laura,   "invitadosVip");
        Agregar(invitadosVip, roberto, "invitadosVip");
        Agregar(invitadosVip, diana,   "invitadosVip");
        // invitadosVip.Count = 3 ✓

        // ── Lista negra: 2 — Caso 3 ──────────────────────────────────────────
        // Aunque carlos y felipe están en preregistrados y registroManual,
        // serán eliminados de autorizados en ProcesarConciliacion con ExceptWith
        listaNegra.Add(carlos);
        listaNegra.Add(felipe);
        // listaNegra.Count = 2 ✓

        // ── Asistentes reales: 14 ────────────────────────────────────────────
        // Son las personas que físicamente entraron al evento.
        // carlos y felipe (lista negra) y intruso (sin registro) disparan noAutorizados.
        // tomas, marta, laura, roberto, diana no asistieron → quedarán como ausentes.
        asistentesReales.Add(ana);
        asistentesReales.Add(luis);
        asistentesReales.Add(pedro);
        asistentesReales.Add(mario);
        asistentesReales.Add(jorge);
        asistentesReales.Add(camila);
        asistentesReales.Add(andres);
        asistentesReales.Add(valeria);
        asistentesReales.Add(daniela);
        asistentesReales.Add(isabela);
        asistentesReales.Add(lucia);
        asistentesReales.Add(carlos);  // Caso 3: en lista negra → no autorizado
        asistentesReales.Add(intruso); // Caso 4: nunca registrado → no autorizado
        asistentesReales.Add(felipe);  // Caso 3: en lista negra → no autorizado
        // asistentesReales.Count = 14 ✓

        Console.WriteLine("\nDatos cargados correctamente.");
        Console.WriteLine($"  Preregistrados:  {preregistrados.Count}");
        Console.WriteLine($"  Registro manual: {registroManual.Count}");
        Console.WriteLine($"  Invitados VIP:   {invitadosVip.Count}");
        Console.WriteLine($"  Lista negra:     {listaNegra.Count}");
        Console.WriteLine($"  Asistentes:      {asistentesReales.Count}");
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    // ════════════════════════════════════════════════════════════════
    //  MÉTODO AUXILIAR — Agregar participante a un HashSet
    //  Intenta agregar p al conjunto. Si ya existe (HashSet.Add = false),
    //  registra el duplicado con el motivo correspondiente.
    // ════════════════════════════════════════════════════════════════
    static void Agregar(
        HashSet<Participante> conjunto, Participante p, string origen,
        bool esDupDoc = false, bool esDupEmail = false, string valor = "")
    {
        if (!conjunto.Add(p)) // Add() retorna false si el elemento ya existe según Equals
        {
            if (esDupDoc)        duplicados.Add($"Documento repetido: {valor}");
            else if (esDupEmail) duplicados.Add($"Email repetido: {valor}");
            // Si ningún flag está activo, el duplicado se ignora silenciosamente
        }
    }

    // ════════════════════════════════════════════════════════════════
    //  OPCIÓN 2 — Procesar conciliación
    //  Aplica las fórmulas de conjuntos del enunciado y valida las
    //  inscripciones a talleres cubriendo los casos 5 y 6.
    // ════════════════════════════════════════════════════════════════
    static void ProcesarConciliacion()
    {
        // No procesar si aún no se cargaron datos
        if (preregistrados.Count == 0)
        {
            Console.WriteLine("\nPrimero carga los datos (Opción 1).");
            Console.ReadKey();
            return;
        }

        // Limpiar resultados anteriores en caso de reprocesar
        rechazos.Clear(); inscripciones.Clear(); cupos.Clear();

        // ── Cálculo de autorizados ────────────────────────────────────────────
        // Fórmula: autorizados = (preregistrados ∪ registroManual ∪ invitadosVip) - listaNegra
        // UnionWith une dos conjuntos eliminando duplicados automáticamente
        autorizados = new HashSet<Participante>(preregistrados); // copia para no modificar el original
        autorizados.UnionWith(registroManual); // agrega los del manual que no estén ya en pre
        autorizados.UnionWith(invitadosVip);   // agrega los VIP que no estén ya
        autorizados.ExceptWith(listaNegra);    // elimina a los que están en lista negra

        // ── Asistentes no autorizados ─────────────────────────────────────────
        // Fórmula: noAutorizados = asistentesReales - autorizados
        // Son quienes entraron pero no tenían permiso
        noAutorizados = new HashSet<Participante>(asistentesReales);
        noAutorizados.ExceptWith(autorizados);

        // ── Autorizados ausentes ──────────────────────────────────────────────
        // Fórmula: ausentes = autorizados - asistentesReales
        // Tenían permiso pero no se presentaron
        ausentes = new HashSet<Participante>(autorizados);
        ausentes.ExceptWith(asistentesReales);

        // ── Autorizados que sí asistieron (IntersectWith) ────────────────────
        // Intersección: elementos que están en ambos conjuntos
        var presentes = new HashSet<Participante>(autorizados);
        presentes.IntersectWith(asistentesReales);

        // ── Validación de consistencia (IsSubsetOf) ───────────────────────────
        // Los ausentes siempre deben ser subconjunto de los autorizados.
        // Si esto fuera false, habría un error en la lógica del sistema.
        bool ausentesValidos = ausentes.IsSubsetOf(autorizados);

        // ── Inscripciones a talleres ──────────────────────────────────────────
        var t1 = talleres[0]; // Clean Code          09:00-11:00
        var t2 = talleres[1]; // Microservicios       10:00-12:00 (solapa con t1 → Caso 5)
        var t3 = talleres[2]; // Docker Pro           13:00-15:00 (cap=1 → Caso 6)

        Inscribir(Buscar(autorizados, "123"),  t1); // Ana  → válida
        Inscribir(Buscar(autorizados, "123"),  t2); // Ana  → Caso 5: cruce de horario con t1
        Inscribir(Buscar(autorizados, "999"),  t1); // Luis → válida
        Inscribir(Buscar(autorizados, "5566"), t3); // Pedro → válida, ocupa el único cupo de Docker Pro
        Inscribir(Buscar(autorizados, "3344"), t3); // Mario → Caso 6: Docker Pro ya está lleno

        conciliado = true;
        Console.WriteLine("\nConciliación procesada.");
        Console.WriteLine($"  Autorizados:              {autorizados.Count}");
        Console.WriteLine($"  Presentes autorizados:    {presentes.Count}");
        Console.WriteLine($"  Ausentes:                 {ausentes.Count}");
        Console.WriteLine($"  Ausentes ⊆ Autorizados:   {ausentesValidos}");
        Console.WriteLine($"  No autorizados:           {noAutorizados.Count}");
        Console.WriteLine($"  Inscripciones válidas:    {inscripciones.Count}");
        Console.WriteLine($"  Inscripciones rechazadas: {rechazos.Count}");
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    // ════════════════════════════════════════════════════════════════
    //  MÉTODO AUXILIAR — Buscar participante por documento
    //  Recorre el conjunto hasta encontrar el documento buscado.
    //  Retorna null si no existe (evita excepciones en Inscribir).
    // ════════════════════════════════════════════════════════════════
    static Participante? Buscar(HashSet<Participante> conjunto, string doc)
    {
        foreach (var p in conjunto)
            if (p.Documento == doc) return p;
        return null;
    }

    // ════════════════════════════════════════════════════════════════
    //  MÉTODO AUXILIAR — Intentar inscribir un participante a un taller
    //  Valida las tres reglas de negocio en orden:
    //    1. El participante debe estar autorizado
    //    2. El taller no debe estar lleno
    //    3. El participante no puede tener otro taller solapado
    //  Si todas pasan, se registra la inscripción y se descuenta un cupo.
    // ════════════════════════════════════════════════════════════════
    static void Inscribir(Participante? p, Taller t)
    {
        // Si Buscar() no encontró al participante, no hay nada que hacer
        if (p is null) return;

        // Regla 1: el participante debe estar en el conjunto de autorizados
        if (!autorizados.Contains(p))
        {
            rechazos.Add($"{p.NombreCompleto} -> Taller \"{t.Nombre}\" | Motivo: no autorizado");
            return;
        }

        // Regla 2: el taller no debe haber superado su capacidad máxima
        if (cupos.GetValueOrDefault(t) >= t.Capacidad)
        {
            rechazos.Add($"{p.NombreCompleto} -> Taller \"{t.Nombre}\" | Motivo: sin cupo");
            return;
        }

        // Regla 3: el participante no puede estar ya inscrito en otro taller
        // que se solape en horario con el que se intenta agregar.
        // Dos talleres se solapan si uno empieza antes de que el otro termine.
        foreach (var ins in inscripciones)
        {
            if (ins.Participante.Equals(p) &&
                ins.Taller.HoraInicio < t.HoraFin &&
                t.HoraInicio < ins.Taller.HoraFin)
            {
                rechazos.Add($"{p.NombreCompleto} -> Taller \"{t.Nombre}\" | Motivo: cruce de horario");
                return;
            }
        }

        // Todas las reglas pasaron: inscripción válida
        inscripciones.Add(new InscripcionTaller { Participante = p, Taller = t });
        cupos[t] = cupos.GetValueOrDefault(t) + 1; // descontar un cupo del taller
    }

    // ════════════════════════════════════════════════════════════════
    //  OPCIÓN 3 — Mostrar reporte consolidado
    //  Imprime en consola el resumen completo de la conciliación.
    // ════════════════════════════════════════════════════════════════
    static void MostrarReporte()
    {
        // Solo mostrar si ya se procesó la conciliación
        if (!conciliado)
        {
            Console.WriteLine("\nPrimero procesa la conciliación (Opción 2).");
            Console.ReadKey();
            return;
        }

        Console.Clear();
        Console.WriteLine("===== REPORTE FINAL =====");

        // Totales por fuente
        Console.WriteLine($"Preregistrados: {preregistrados.Count}");
        Console.WriteLine($"Registro manual: {registroManual.Count}");
        Console.WriteLine($"Invitados VIP: {invitadosVip.Count}");
        Console.WriteLine($"Lista negra: {listaNegra.Count}");
        Console.WriteLine($"Autorizados finales: {autorizados.Count}");
        Console.WriteLine($"Asistentes reales: {asistentesReales.Count}");

        // Personas que entraron sin permiso (asistentesReales - autorizados)
        Console.WriteLine("\nNo autorizados:");
        foreach (var p in noAutorizados) Console.WriteLine($"- {p}");

        // Personas autorizadas que no se presentaron (autorizados - asistentesReales)
        Console.WriteLine("\nAutorizados ausentes:");
        foreach (var p in ausentes) Console.WriteLine($"- {p}");

        // Inscripciones que no pudieron completarse y su motivo
        Console.WriteLine("\nInscripciones rechazadas:");
        foreach (var r in rechazos) Console.WriteLine($"- {r}");

        // Intentos de registro duplicado detectados al cargar datos
        Console.WriteLine("\nDuplicados detectados en carga:");
        foreach (var d in duplicados) Console.WriteLine($"- {d}");

        // Talleres que alcanzaron su capacidad máxima
        Console.WriteLine("\nTalleres llenos:");
        foreach (var t in talleres)
            if (cupos.GetValueOrDefault(t) >= t.Capacidad)
                Console.WriteLine($"- {t.Nombre}");

        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
}