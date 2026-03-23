using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class NombresDuplicados
    {
        public static void Ejecutar()
        {
            // Lista original
            List<string> nombres = new List<string>();

            Console.WriteLine("Ingrese 10 nombres:\n");

            // Pedimos los 10 nombres
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"Nombre {i}: ");
                string nombre = Console.ReadLine() ?? "";

                // Normalizamos (opcional pero recomendado)
                nombre = nombre.Trim().ToLower();

                nombres.Add(nombre);
            }

            // HashSet para controlar los vistos
            HashSet<string> vistos = new HashSet<string>();

            // HashSet para guardar duplicados
            HashSet<string> duplicados = new HashSet<string>();

            // Recorremos la lista
            foreach (string n in nombres)
            {
                // Si no se puede agregar a "vistos", ya estaba → duplicado
                if (!vistos.Add(n))
                {
                    duplicados.Add(n);
                }
            }

            // Mostramos resultados
            Console.WriteLine("\nNombres ingresados:");
            foreach (string n in nombres)
            {
                Console.Write(n + " ");
            }

            Console.WriteLine("\n\nNombres duplicados:");

            if (duplicados.Count == 0)
            {
                Console.WriteLine("No hay nombres repetidos.");
            }
            else
            {
                foreach (string d in duplicados)
                {
                    Console.WriteLine("- " + d);
                }
            }

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}