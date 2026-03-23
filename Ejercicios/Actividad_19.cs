using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class RegistroNotas
    {
        public static void Ejecutar()
        {
            // Lista para guardar las notas
            List<double> notas = new List<double>();

            Console.WriteLine("Ingrese notas (escriba -1 para terminar):\n");

            while (true)
            {
                Console.Write("Nota: ");
                double nota = double.Parse(Console.ReadLine() ?? "0");

                // Condición de salida
                if (nota == -1)
                    break;

                // Validación simple (opcional, pero recomendada)
                if (nota < 0 || nota > 5)
                {
                    Console.WriteLine("Nota inválida (debe estar entre 0 y 5).");
                    continue;
                }

                notas.Add(nota);
            }

            // Verificamos que haya al menos una nota
            if (notas.Count == 0)
            {
                Console.WriteLine("\nNo se ingresaron notas.");
            }
            else
            {
                double suma = 0;
                int buenas = 0;

                Console.WriteLine("\nNotas ingresadas:");

                foreach (double n in notas)
                {
                    Console.WriteLine("- " + n);

                    suma += n;

                    if (n >= 3.0)
                        buenas++;
                }

                double promedio = suma / notas.Count;

                Console.WriteLine($"\nPromedio: {promedio:F2}");
                Console.WriteLine($"Notas >= 3.0: {buenas}");
            }

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}