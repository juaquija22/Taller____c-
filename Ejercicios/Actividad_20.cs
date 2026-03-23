using System;

namespace Taller____c_.Ejercicios
{
    public class MenuBasico
    {
        public static void Ejecutar()
        {
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== MENÚ BÁSICO =====");
                Console.WriteLine("1. Saludar");
                Console.WriteLine("2. Mostrar fecha simulada");
                Console.WriteLine("3. Calcular cuadrado de un número");
                Console.WriteLine("4. Salir");
                Console.Write("\nSeleccione una opción: ");

                opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("\nHola, bienvenido al sistema.");
                        break;

                    case "2":
                        // Fecha simulada (puedes cambiarla)
                        Console.WriteLine("\nFecha simulada: 23/03/2026");
                        break;

                    case "3":
                        Console.Write("\nIngrese un número: ");
                        int num = int.Parse(Console.ReadLine() ?? "0");

                        int cuadrado = num * num;

                        Console.WriteLine($"El cuadrado de {num} es {cuadrado}");
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