using System;
using System.Collections;

namespace Taller____c_.Ejercicios
{
    public class InventarioArrayList
    {
        public static void Ejecutar()
        {
            // ArrayList para guardar productos (no genérico)
            ArrayList productos = new ArrayList();

            Console.WriteLine("Ingrese productos (escriba 'salir' para terminar):\n");

            while (true)
            {
                Console.Write("Producto: ");
                string nombre = Console.ReadLine() ?? "";

                // Condición de salida
                if (nombre.ToLower() == "salir")
                    break;

                // Agregamos el producto
                productos.Add(nombre);
            }

            // Mostramos los productos registrados
            Console.WriteLine("\nProductos registrados:");

            foreach (var p in productos)
            {
                Console.WriteLine("- " + p);
            }

            Console.WriteLine($"\nTotal de productos: {productos.Count}");

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}