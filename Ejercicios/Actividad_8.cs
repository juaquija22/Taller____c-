using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class Anagramas
    {
        public static void Ejecutar()
        {
            // Pedimos las dos palabras
            Console.WriteLine("Ingrese la primera palabra:");
            string palabra1 = Console.ReadLine() ?? "";

            Console.WriteLine("Ingrese la segunda palabra:");
            string palabra2 = Console.ReadLine() ?? "";

            bool resultado = EsAnagrama(palabra1, palabra2);

            Console.WriteLine(resultado ? "true" : "false");
        }

        static bool EsAnagrama(string a, string b)
        {
            // Quitamos espacios y pasamos a minúsculas
            a = a.Replace(" ", "").ToLower();
            b = b.Replace(" ", "").ToLower();

            // Si son exactamente iguales, no son anagramas
            if (a == b)
                return false;

            // Si tienen diferente longitud, no pueden ser anagramas
            if (a.Length != b.Length)
                return false;

            // Diccionario para contar letras
            Dictionary<char, int> conteo = new Dictionary<char, int>();

            // Contamos letras de la primera palabra
            foreach (char c in a)
            {
                if (conteo.ContainsKey(c))
                    conteo[c]++;
                else
                    conteo[c] = 1;
            }

            // Restamos usando la segunda palabra
            foreach (char c in b)
            {
                // Si no existe la letra, no es anagrama
                if (!conteo.ContainsKey(c))
                    return false;

                conteo[c]--;

                // Si queda negativo, hay más letras en b que en a
                if (conteo[c] < 0)
                    return false;
            }

            // Si todo salió bien, es anagrama
            return true;
        }
    }
}