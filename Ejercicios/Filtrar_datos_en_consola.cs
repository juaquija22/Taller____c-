using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios;

public class Filtrar_datos_en_consola

{
    static List<string> filas = new()
    {
        "1 | Ana García | Bogotá | 4500",
        "2 | Juan Pérez | Medellín | 5200",
        "3 | María López | Bogotá | 3800",
        "4 | Carlos Ruiz | Cali | 6100",
        "5 | Julia Soto | Medellín | 4700",
        "6 | Pedro Gómez | Barranquilla | 3900"
    };

public static void Ejecutar()
{
    Console.Clear(); // ← Agrega esto
    Console.WriteLine("Filtrar datos en consola (escribe 'exit' para salir)");

    while (true)
    {
        Console.Write("\nTexto a buscar: ");
        string texto = Console.ReadLine() ?? "";

        if (texto.ToLower() == "exit") break;

        Console.WriteLine("\nFilas encontradas:");

        bool encontrado = false;

        foreach (var fila in filas)
        {
            if (fila.Contains(texto, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(fila);
                encontrado = true;
            }
        }

        if (!encontrado)
            Console.WriteLine("No hay coincidencias.");
    }
}
}

