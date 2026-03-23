using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class FiltrarPares
    {
        public static void Ejecutar()
        {
            // Lista original
            List<int> numeros = new List<int>();

            Console.WriteLine("Ingrese 10 números:\n");

            // Llenamos la lista con 10 números
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"Número {i}: ");
                int num = int.Parse(Console.ReadLine() ?? "0");
                numeros.Add(num);
            }

            // Nueva lista solo con números pares
            List<int> pares = new List<int>();

            // Recorremos la lista original
            foreach (int n in numeros)
            {
                // Si es par, lo agregamos a la nueva lista
                if (n % 2 == 0)
                {
                    pares.Add(n);
                }
            }

            // Mostramos la lista de pares
            Console.WriteLine("\nNúmeros pares:");

            foreach (int p in pares)
            {
                Console.Write(p + " ");
            }

            Console.WriteLine("\n\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}