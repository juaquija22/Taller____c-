using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class CorreosSinRepetidos
    {
        public static void Ejecutar()
        {
            // HashSet para almacenar correos únicos
            HashSet<string> correos = new HashSet<string>();

            Console.WriteLine("Ingrese correos (escriba 'salir' para terminar):\n");

            while (true)
            {
                Console.Write("Correo: ");
                string entrada = Console.ReadLine() ?? "";

                // Normalizamos (evita duplicados por espacios o mayúsculas)
                string correo = entrada.Trim().ToLower();

                // Condición de salida
                if (correo == "salir")
                    break;

                // Validación simple (opcional)
                if (!correo.Contains("@"))
                {
                    Console.WriteLine("Correo inválido.");
                    continue;
                }

                // Intentamos agregar al HashSet
                if (correos.Add(correo))
                {
                    Console.WriteLine("Correo agregado correctamente.");
                }
                else
                {
                    Console.WriteLine("El correo ya estaba registrado.");
                }
            }

            // Mostrar todos los correos
            Console.WriteLine("\nCorreos registrados:");

            foreach (string c in correos)
            {
                Console.WriteLine("- " + c);
            }

            Console.WriteLine($"\nTotal de correos únicos: {correos.Count}");

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}