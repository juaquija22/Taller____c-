using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class GestionEdades
    {
        public static void Ejecutar()
        {
            // Lista para guardar las edades
            List<int> edades = new List<int>();

            Console.WriteLine("Ingrese edades (escriba -1 para terminar):\n");

            while (true)
            {
                Console.Write("Edad: ");
                int edad = int.Parse(Console.ReadLine() ?? "0");

                // Condición de salida
                if (edad == -1)
                    break;

                // Validación básica
                if (edad < 0)
                {
                    Console.WriteLine("Edad inválida.");
                    continue;
                }

                edades.Add(edad);
            }

            // Verificamos si hay datos
            if (edades.Count == 0)
            {
                Console.WriteLine("\nNo se ingresaron edades.");
            }
            else
            {
                int suma = 0;
                int mayores = 0;
                int menores = 0;

                foreach (int e in edades)
                {
                    suma += e;

                    if (e >= 18)
                        mayores++;
                    else
                        menores++;
                }

                double promedio = (double)suma / edades.Count;

                // Resultados
                Console.WriteLine("\nResultados:");
                Console.WriteLine($"Cantidad de edades: {edades.Count}");
                Console.WriteLine($"Promedio: {promedio:F2}");
                Console.WriteLine($"Mayores de edad: {mayores}");
                Console.WriteLine($"Menores de edad: {menores}");
            }

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}