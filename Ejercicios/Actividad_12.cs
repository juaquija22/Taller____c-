using System;

namespace Taller____c_.Ejercicios
{
    public class NumerosPares
    {
        public static void Ejecutar()
        {
            // Variable para contar los números pares
            int contador = 0;

            Console.WriteLine("Números pares del 1 al 100:\n");

            // Recorremos del 1 al 100
            for (int i = 1; i <= 100; i++)
            {
                // Verificamos si es par
                if (i % 2 == 0)
                {
                    Console.Write(i + " "); // Mostramos el número
                    contador++;             // Aumentamos el contador
                }
            }

            // Mostramos el total
            Console.WriteLine($"\n\nTotal de números pares: {contador}");

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}