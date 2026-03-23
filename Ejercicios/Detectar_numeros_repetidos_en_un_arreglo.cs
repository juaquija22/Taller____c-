using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class NumerosRepetidos
    {
        public static void Ejecutar()
        {
            Console.WriteLine("Ingrese números separados por coma (ej: 10,3,5,3,10):");
            string entrada = Console.ReadLine() ?? "";

            string[] partes = entrada.Split(',');
            int[] numeros = new int[partes.Length];

            for (int i = 0; i < partes.Length; i++)
            {
                numeros[i] = int.Parse(partes[i]);
            }

            int[] repetidos = ObtenerRepetidos(numeros);

            Console.WriteLine("Números repetidos:");
            foreach (int num in repetidos)
            {
                Console.Write(num + " ");
            }
        }

        static int[] ObtenerRepetidos(int[] arreglo)
        {
            HashSet<int> vistos = new HashSet<int>();
            HashSet<int> repetidos = new HashSet<int>();

            foreach (int num in arreglo)
            {
                if (!vistos.Add(num))
                {
                    repetidos.Add(num);
                }
            }

            return new List<int>(repetidos).ToArray();
        }
    }
}