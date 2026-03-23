using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class PalabrasUnicas
    {
        public static void Ejecutar()
        {
            // HashSet para almacenar palabras únicas
            HashSet<string> palabras = new HashSet<string>();

            Console.WriteLine("Ingrese 8 palabras:\n");

            // Pedimos 8 palabras
            for (int i = 1; i <= 8; i++)
            {
                Console.Write($"Palabra {i}: ");
                string palabra = Console.ReadLine() ?? "";

                // Normalizamos (opcional pero recomendado)
                palabra = palabra.Trim().ToLower();

                palabras.Add(palabra); // HashSet evita duplicados automáticamente
            }

            // Mostramos resultados
            Console.WriteLine("\nPalabras únicas ingresadas:");

            foreach (string p in palabras)
            {
                Console.WriteLine("- " + p);
            }

            Console.WriteLine($"\nTotal de palabras únicas: {palabras.Count}");

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}