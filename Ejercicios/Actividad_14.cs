using System;

namespace Taller____c_.Ejercicios
{
    public class SumaHastaCero
    {
        public static void Ejecutar()
        {
            int suma = 0;      // Acumulador de la suma
            int numero = -1;   // Variable para guardar el número ingresado

            Console.WriteLine("Ingrese números (0 para terminar):\n");

            // Se repite hasta que el usuario ingrese 0
            while (numero != 0)
            {
                Console.Write("Número: ");
                numero = int.Parse(Console.ReadLine() ?? "0");

                // Si no es 0, lo sumamos
                if (numero != 0)
                {
                    suma += numero;
                }
            }

            // Mostramos el resultado final
            Console.WriteLine($"\nSuma total: {suma}");

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}