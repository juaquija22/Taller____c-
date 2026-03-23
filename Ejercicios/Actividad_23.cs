using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class NumerosUnicos
    {
        public static void Ejecutar()
        {
            // Lista para guardar todos los números (incluye repetidos)
            List<int> numeros = new List<int>();

            Console.WriteLine("Ingrese 12 números:\n");

            // Pedimos los 12 números
            for (int i = 1; i <= 12; i++)
            {
                Console.Write($"Número {i}: ");
                int num = int.Parse(Console.ReadLine() ?? "0");
                numeros.Add(num);
            }

            // Mostramos todos los números ingresados
            Console.WriteLine("\nNúmeros ingresados:");
            foreach (int n in numeros)
            {
                Console.Write(n + " ");
            }

            // Creamos un HashSet a partir de la lista
            // Esto elimina automáticamente los duplicados
            HashSet<int> unicos = new HashSet<int>(numeros);

            // Mostramos los números únicos
            Console.WriteLine("\n\nNúmeros únicos:");
            foreach (int u in unicos)
            {
                Console.Write(u + " ");
            }

            // Mostramos cuántos son únicos
            Console.WriteLine($"\n\nCantidad de números únicos: {unicos.Count}");

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}