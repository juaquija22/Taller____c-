using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class MultiplosDeTres
    {
        public static void Ejecutar()
        {
            // Lista original
            List<int> numeros = new List<int>();

            Console.WriteLine("Ingrese 15 números:\n");

            // Pedimos los 15 números
            for (int i = 1; i <= 15; i++)
            {
                Console.Write($"Número {i}: ");
                int num = int.Parse(Console.ReadLine() ?? "0");
                numeros.Add(num);
            }

            // Lista para múltiplos de 3
            List<int> multiplos = new List<int>();

            // Recorremos la lista original
            foreach (int n in numeros)
            {
                // Verificamos si es múltiplo de 3
                if (n % 3 == 0)
                {
                    multiplos.Add(n);
                }
            }

            // Mostramos la lista original
            Console.WriteLine("\nLista original:");
            foreach (int n in numeros)
            {
                Console.Write(n + " ");
            }

            // Mostramos los múltiplos de 3
            Console.WriteLine("\n\nMúltiplos de 3:");
            foreach (int m in multiplos)
            {
                Console.Write(m + " ");
            }

            Console.WriteLine("\n\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}