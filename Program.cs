using System;
using System.ComponentModel.Design;
using Taller____c_.Ejercicios;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== MENU DE EJERCICIOS =====");
            Console.WriteLine("1. Filtrar datos en consola");
            Console.WriteLine("2. Detectar números repetidos");
            Console.WriteLine("3. Generador de contraseñas");
            Console.WriteLine("4. Frecuencia de caracteres");
            Console.WriteLine("5. Subconjunto con suma");
            Console.WriteLine("6. Permutaciones de cadena");
            Console.WriteLine("7. Signos equilibrados");
            Console.WriteLine("8. Anagramas");
            Console.WriteLine("9. Sistema de eventos (HashSet)");
            Console.WriteLine("10. Correos sin duplicados");
            Console.WriteLine("11. Registro de estudiantes");
            Console.WriteLine("12. Números pares");
            Console.WriteLine("13. Tabla de multiplicar");
            Console.WriteLine("14. Suma hasta 0");
            Console.WriteLine("15. Contador positivos/negativos");
            Console.WriteLine("16. Mayor, menor y promedio");
            Console.WriteLine("17. Lista de nombres");
            Console.WriteLine("18. Eliminar impares");
            Console.WriteLine("19. Registro de notas");
            Console.WriteLine("20. Menú básico");
            Console.WriteLine("21. Palabras únicas");
            Console.WriteLine("22. Correos HashSet");
            Console.WriteLine("23. Números únicos");
            Console.WriteLine("24. Inventario ArrayList");
            Console.WriteLine("25. ArrayList mixto");
            Console.WriteLine("26. Múltiplos de 3");
            Console.WriteLine("27. Control de acceso");
            Console.WriteLine("28. Lista de compras");
            Console.WriteLine("29. Detectar duplicados");
            Console.WriteLine("30. Gestión de edades");
            Console.WriteLine("31. Consolidador de números");
            Console.WriteLine("32. Rutas con Dijkstra");
            Console.WriteLine("0. Salir");

            Console.Write("\nSeleccione una opción: ");
            string opcion = Console.ReadLine() ?? "";
            Console.Clear(); 

            switch (opcion)
            {
                case "1":  Filtrar_datos_en_consola.Ejecutar(); break;
                case "2":  NumerosRepetidos.Ejecutar(); break; 
                case "3":  Generador_de_contrasenas.Ejecutar(); break;
                case "4":  FrecuenciaCaracteres.Ejecutar(); break;
                case "5":  SubconjuntoSuma.Ejecutar(); break;
                case "6":  PermutacionesCadena.Ejecutar(); break;
                case "7":  SimbolosEquilibrados.Ejecutar(); break;
                case "8":  Anagramas.Ejecutar(); break;
                case "9":  Conciliacion_Asistentes_Talleres.Ejecutar();break;
                case "10": CorreosUnicos.Ejecutar(); break;
                case "11": ControlEstudiantes.Ejecutar(); break;
                case "12": NumerosPares.Ejecutar(); break;
                case "13": TablaMultiplicar.Ejecutar(); break;
                case "14": SumaHastaCero.Ejecutar(); break;
                case "15": ContadorNumeros.Ejecutar(); break;
                case "16": MayorMenorPromedio.Ejecutar(); break;
                case "17": BuscarNombre.Ejecutar(); break;
                case "18": FiltrarPares.Ejecutar(); break;
                case "19": RegistroNotas.Ejecutar(); break;
                case "20": MenuBasico.Ejecutar(); break;
                case "21": PalabrasUnicas.Ejecutar(); break;
                case "22": CorreosSinRepetidos.Ejecutar(); break;
                case "23": NumerosUnicos.Ejecutar(); break;
                case "24": InventarioArrayList.Ejecutar(); break;
                case "25": ArrayListMixto.Ejecutar(); break;
                case "26": MultiplosDeTres.Ejecutar(); break;
                case "27": ControlAcceso.Ejecutar(); break;
                case "28": ListaCompras.Ejecutar(); break;
                case "29": NombresDuplicados.Ejecutar(); break;
                case "30": GestionEdades.Ejecutar(); break;
                case "31": ConsolidadorNumeros.Ejecutar(); break;
                case "32": SistemaRutas.Ejecutar(); break;
                case "0":
                    Console.WriteLine("Saliendo...");
                    return;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            Console.WriteLine("\nPresiona ENTER para volver al menú...");
            Console.ReadLine();
        }
    }
}