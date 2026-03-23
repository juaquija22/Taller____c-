using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class CorreosUnicos
    {
        public static void Ejecutar()
        {
            // HashSet para almacenar correos únicos
            HashSet<string> correos = new HashSet<string>();

            while (true)
            {
                Console.Write("\nIngrese un correo (o escriba 'salir'): ");
                string entrada = Console.ReadLine() ?? "";

                // Convertimos a minúsculas y quitamos espacios
                string correo = entrada.Trim().ToLower();

                // Condición para salir del programa
                if (correo == "salir")
                    break;

                // Intentamos agregar el correo al HashSet
                // Add() retorna:
                // true  → si se agregó correctamente
                // false → si ya existía
                if (correos.Add(correo))
                {
                    Console.WriteLine("Correo agregado correctamente.");
                }
                else
                {
                    Console.WriteLine("El correo ya estaba registrado.");
                }
            }

            // Mostrar todos los correos registrados
            Console.WriteLine("\nCorreos registrados:");

            foreach (string c in correos)
            {
                Console.WriteLine("- " + c);
            }

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}