using System;

namespace Taller____c_.Ejercicios
{
    public class PermutacionesCadena
    {
        public static void Ejecutar()
        {
            // Pedimos la cadena
            Console.WriteLine("Ingrese una cadena:");
            string texto = Console.ReadLine() ?? "";

            Console.WriteLine("\nPermutaciones:");

            // Llamamos a la función recursiva
            GenerarPermutaciones(texto, "");
        }

        // Función recursiva
        static void GenerarPermutaciones(string restante, string actual)
        {
            // CASO BASE:
            // Si ya no quedan caracteres por usar
            if (restante.Length == 0)
            {
                // Imprimimos una permutación completa
                Console.WriteLine(actual);
                return;
            }

            // Recorremos cada carácter disponible
            for (int i = 0; i < restante.Length; i++)
            {
                // Elegimos un carácter
                char elegido = restante[i];

                // Creamos un nuevo string sin el carácter elegido
                string nuevoRestante = restante.Substring(0, i) + restante.Substring(i + 1);

                // Agregamos el carácter elegido al resultado parcial
                string nuevoActual = actual + elegido;

                // Llamada recursiva
                GenerarPermutaciones(nuevoRestante, nuevoActual);
            }
        }
    }
}