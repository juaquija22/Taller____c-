using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class MayorMenorPromedio
    {
        public static void Ejecutar()
        {
            // Lista para guardar los números
            List<int> numeros = new List<int>();

            Console.WriteLine("Ingrese 8 números:\n");

            // Pedimos los 8 números
            for (int i = 1; i <= 8; i++)
            {
                Console.Write($"Número {i}: ");
                int num = int.Parse(Console.ReadLine() ?? "0");
                numeros.Add(num);
            }

            // Inicializamos mayor y menor con el primer elemento
            int mayor = numeros[0];
            int menor = numeros[0];
            int suma = 0;

            // Recorremos la lista con foreach
            foreach (int n in numeros)
            {
                // Sumamos para el promedio
                suma += n;

                // Verificamos mayor
                if (n > mayor)
                    mayor = n;

                // Verificamos menor
                if (n < menor)
                    menor = n;
            }

            // Calculamos el promedio
            double promedio = (double)suma / numeros.Count;

            // Mostramos resultados
            Console.WriteLine("\nResultados:");
            Console.WriteLine($"Mayor: {mayor}");
            Console.WriteLine($"Menor: {menor}");
            Console.WriteLine($"Promedio: {promedio:F2}");

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}