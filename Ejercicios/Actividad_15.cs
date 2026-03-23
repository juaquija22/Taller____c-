using System;

namespace Taller____c_.Ejercicios
{
    public class ContadorNumeros
    {
        public static void Ejecutar()
        {
            int positivos = 0;
            int negativos = 0;
            int ceros = 0;

            Console.WriteLine("Ingrese 10 números:\n");

            // Ciclo para pedir exactamente 10 números
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"Número {i}: ");
                int numero = int.Parse(Console.ReadLine() ?? "0");

                // Clasificamos el número
                if (numero > 0)
                {
                    positivos++;
                }
                else if (numero < 0)
                {
                    negativos++;
                }
                else
                {
                    ceros++;
                }
            }

            // Mostramos resultados
            Console.WriteLine("\nResultados:");
            Console.WriteLine($"Positivos: {positivos}");
            Console.WriteLine($"Negativos: {negativos}");
            Console.WriteLine($"Ceros: {ceros}");

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}