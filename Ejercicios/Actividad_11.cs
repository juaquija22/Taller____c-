using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    // Clase Estudiante
    public class Estudiante : IEquatable<Estudiante>
    {
        public string Codigo { get; set; } = "";
        public string Nombre { get; set; } = "";

        // Definimos cuándo dos estudiantes son iguales
        // En este caso: si tienen el mismo Código
        public bool Equals(Estudiante? other)
        {
            if (other == null) return false;
            return Codigo == other.Codigo;
        }

        // Sobrescribimos Equals de object
        public override bool Equals(object? obj)
        {
            return Equals(obj as Estudiante);
        }

        // Hash basado en el Código
        public override int GetHashCode()
        {
            return Codigo.GetHashCode();
        }
    }

    public class ControlEstudiantes
    {
        public static void Ejecutar()
        {
            // HashSet para almacenar estudiantes únicos
            HashSet<Estudiante> estudiantes = new HashSet<Estudiante>();

            while (true)
            {
                Console.Write("\nIngrese código (o escriba 'salir'): ");
                string codigo = Console.ReadLine() ?? "";

                if (codigo.ToLower() == "salir")
                    break;

                Console.Write("Ingrese nombre: ");
                string nombre = Console.ReadLine() ?? "";

                Estudiante nuevo = new Estudiante
                {
                    Codigo = codigo,
                    Nombre = nombre
                };

                // Intentamos agregar al HashSet
                if (estudiantes.Add(nuevo))
                {
                    Console.WriteLine("Estudiante agregado correctamente.");
                }
                else
                {
                    Console.WriteLine("El estudiante ya está registrado.");
                }
            }

            // Mostrar estudiantes registrados
            Console.WriteLine("\nEstudiantes registrados:");

            foreach (var e in estudiantes)
            {
                Console.WriteLine($"- Código: {e.Codigo} | Nombre: {e.Nombre}");
            }

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}