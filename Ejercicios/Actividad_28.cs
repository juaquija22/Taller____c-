using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class ListaCompras
    {
        public static void Ejecutar()
        {
            List<string> productos = new List<string>();
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== LISTA DE COMPRAS =====");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Mostrar productos");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Salir");
                Console.Write("\nSeleccione una opción: ");

                opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        Console.Write("\nIngrese el nombre del producto: ");
                        string producto = Console.ReadLine() ?? "";

                        productos.Add(producto);
                        Console.WriteLine("Producto agregado correctamente.");
                        break;

                    case "2":
                        Console.WriteLine("\nProductos en la lista:");

                        if (productos.Count == 0)
                        {
                            Console.WriteLine("La lista está vacía.");
                        }
                        else
                        {
                            foreach (string p in productos)
                            {
                                Console.WriteLine("- " + p);
                            }
                        }
                        break;

                    case "3":
                        Console.Write("\nIngrese el producto a eliminar: ");
                        string eliminar = Console.ReadLine() ?? "";

                        // Remove elimina la primera coincidencia
                        if (productos.Remove(eliminar))
                        {
                            Console.WriteLine("Producto eliminado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("El producto no existe en la lista.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("\nSaliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("\nOpción no válida.");
                        break;
                }

                if (opcion != "4")
                {
                    Console.WriteLine("\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != "4");
        }
    }
}