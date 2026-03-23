using System;
using System.Text;

namespace Taller____c_.Ejercicios;

public class Generador_de_contrasenas
{
    public static void Ejecutar()
    {
        Console.Clear();
        Console.WriteLine("=== Generador de Contraseñas Seguras ===\n");

        Random rng = new Random();

        string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string minusculas = "abcdefghijklmnopqrstuvwxyz";
        string digitos    = "0123456789";
        string especiales = "!@#$%&*?+=-/";
        string todos      = mayusculas + minusculas + digitos + especiales;

        int longitud = rng.Next(15, 88);

        char[] password = new char[longitud];

        password[0] = mayusculas[rng.Next(mayusculas.Length)];
        password[1] = minusculas[rng.Next(minusculas.Length)];
        password[2] = digitos[rng.Next(digitos.Length)];
        password[3] = especiales[rng.Next(especiales.Length)];

        for (int i = 4; i < longitud; i++)
            password[i] = todos[rng.Next(todos.Length)];

        for (int i = longitud - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (password[i], password[j]) = (password[j], password[i]);
        }

        string resultado = new string(password);

        Console.WriteLine($"Contraseña generada:");
        Console.WriteLine($"\n  {resultado}\n");
        Console.WriteLine($"Longitud: {longitud} caracteres");
        Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
        Console.ReadKey();
    }
}