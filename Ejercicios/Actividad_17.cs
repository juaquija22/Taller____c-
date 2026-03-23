using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class BuscarNombre
    {
        public static void Ejecutar()
        {
            // Lista para almacenar los nombres
            List<string> nombres = new List<string>();

            Console.WriteLine("Ingrese 5 nombres:\n");

            // Pedimos los 5 nombres
            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"Nombre {i}: ");
                string nombre = Console.ReadLine() ?? "";
                nombres.Add(nombre);
            }

            // Pedimos el nombre a buscar
            Console.Write("\nIngrese un nombre a buscar: ");
            string buscar = Console.ReadLine() ?? "";

            // Verificamos si existe en la lista
            if (nombres.Contains(buscar))
            {
                Console.WriteLine("El nombre sí existe en la lista.");
            }
            else
            {
                Console.WriteLine("El nombre no existe en la lista.");
            }

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
