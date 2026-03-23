using System;

namespace Taller____c_.Ejercicios
{
    public class TablaMultiplicar
    {
        public static void Ejecutar()
        {
            Console.WriteLine("Ingrese un número entero:");

            // Leemos el número del usuario
            int numero = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine($"\nTabla de multiplicar del {numero}:\n");

            // Recorremos del 1 al 10
            for (int i = 1; i <= 10; i++)
            {
                // Mostramos la multiplicación
                Console.WriteLine(numero + " x " + i + " = " + (numero * i));
            }

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}