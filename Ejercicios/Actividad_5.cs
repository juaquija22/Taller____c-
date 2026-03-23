using System;

namespace Taller____c_.Ejercicios
{
    public class SubconjuntoSuma
    {
        public static void Ejecutar()
        {
            // Pedimos al usuario los números
            Console.WriteLine("Ingrese números separados por coma:");
            string entrada = Console.ReadLine() ?? "";

            // Separamos los números por coma
            string[] partes = entrada.Split(',');

            // Creamos el arreglo de enteros
            int[] numeros = new int[partes.Length];

            // Convertimos cada valor a int
            for (int i = 0; i < partes.Length; i++)
            {
                numeros[i] = int.Parse(partes[i]);
            }

            // Pedimos la suma objetivo
            Console.WriteLine("Ingrese la suma objetivo:");
            int objetivo = int.Parse(Console.ReadLine() ?? "0");

            // Llamamos a la función recursiva
            bool existe = ExisteSuma(numeros, objetivo, 0);

            // Mostramos el resultado
            Console.WriteLine(existe ? "true" : "false");
        }

        // Función recursiva que verifica si existe un subconjunto con la suma
        static bool ExisteSuma(int[] arr, int objetivo, int indice)
        {
            // CASO BASE 1:
            // Si el objetivo llega a 0, significa que encontramos una combinación válida
            if (objetivo == 0)
                return true;

            // CASO BASE 2:
            // Si ya recorrimos todo el arreglo o el objetivo es negativo, no hay solución
            if (indice >= arr.Length || objetivo < 0)
                return false;

            // OPCIÓN 1: incluir el número actual en la suma
            // Restamos el valor actual al objetivo y avanzamos al siguiente índice
            if (ExisteSuma(arr, objetivo - arr[indice], indice + 1))
                return true;

            // OPCIÓN 2: no incluir el número actual
            // Solo avanzamos al siguiente índice sin modificar el objetivo
            if (ExisteSuma(arr, objetivo, indice + 1))
                return true;

            // Si ninguna opción funcionó, retornamos false
            return false;
        }
    }
}