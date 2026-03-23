using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class ConsolidadorNumeros
    {
        public static void Ejecutar()
        {
            // Listas
            List<int> lista1 = new List<int>();
            List<int> lista2 = new List<int>();

            Console.WriteLine("Ingrese 5 números para la primera lista:\n");

            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"Lista1 - Número {i}: ");
                int num = int.Parse(Console.ReadLine() ?? "0");
                lista1.Add(num);
            }

            Console.WriteLine("\nIngrese 5 números para la segunda lista:\n");

            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"Lista2 - Número {i}: ");
                int num = int.Parse(Console.ReadLine() ?? "0");
                lista2.Add(num);
            }

            // Mostrar listas
            Console.WriteLine("\nLista 1:");
            foreach (int n in lista1)
                Console.Write(n + " ");

            Console.WriteLine("\nLista 2:");
            foreach (int n in lista2)
                Console.Write(n + " ");

            // HashSet con todos los números (únicos)
            HashSet<int> todos = new HashSet<int>(lista1);
            todos.UnionWith(lista2);

            Console.WriteLine("\n\nValores únicos:");
            foreach (int n in todos)
                Console.Write(n + " ");

            // Detectar repetidos entre ambas listas
            HashSet<int> repetidos = new HashSet<int>(lista1);
            repetidos.IntersectWith(lista2);

            Console.WriteLine($"\n\nCantidad de números repetidos entre ambas listas: {repetidos.Count}");

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}