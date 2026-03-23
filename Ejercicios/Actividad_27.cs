using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class ControlAcceso
    {
        public static void Ejecutar()
        {
            // HashSet para almacenar códigos únicos
            HashSet<string> codigos = new HashSet<string>();

            Console.WriteLine("Ingrese 10 códigos de estudiantes:\n");

            // Pedimos 10 códigos
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"Código {i}: ");
                string codigo = Console.ReadLine() ?? "";

                // Normalizamos (evita duplicados por espacios o mayúsculas)
                codigo = codigo.Trim().ToUpper();

                // Intentamos agregar al HashSet
                if (codigos.Add(codigo))
                {
                    Console.WriteLine("Código registrado correctamente.");
                }
                else
                {
                    Console.WriteLine("Este código ya fue registrado.");
                }
            }

            // Mostramos los códigos registrados
            Console.WriteLine("\nCódigos registrados:");

            foreach (string c in codigos)
            {
                Console.WriteLine("- " + c);
            }

            Console.WriteLine($"\nTotal de códigos únicos: {codigos.Count}");

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}