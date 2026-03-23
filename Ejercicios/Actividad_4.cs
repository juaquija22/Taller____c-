using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class FrecuenciaCaracteres
    {
        public static void Ejecutar()
        {
            // Pedimos al usuario que ingrese una cadena
            Console.WriteLine("Ingrese una cadena de texto:");
            string entrada = Console.ReadLine() ?? "";

            // Convertimos todo a minúsculas para no diferenciar mayúsculas/minúsculas
            string texto = entrada.ToLower();

            // Diccionario donde:
            // Key = carácter (char)
            // Value = cantidad de veces que aparece
            Dictionary<char, int> conteo = new Dictionary<char, int>();

            // Recorremos el texto carácter por carácter
            foreach (char c in texto)
            {
                // Quitamos la tilde manualmente (si tiene)
                char normal = QuitarTilde(c);

                // Validamos que sea letra o número
                if (char.IsLetterOrDigit(normal))
                {
                    // Si ya existe en el diccionario, aumentamos el contador
                    if (conteo.ContainsKey(normal))
                        conteo[normal]++;
                    else
                        // Si no existe, lo agregamos con valor 1
                        conteo[normal] = 1;
                }
            }

            // Ordenamos el diccionario alfabéticamente por la clave (char)
            var ordenado = new SortedDictionary<char, int>(conteo);

            Console.WriteLine("\nFrecuencia de caracteres:");

            // Recorremos el diccionario ordenado y mostramos resultados
            foreach (var item in ordenado)
            {
                Console.WriteLine($"{{ Car = '{item.Key}', Veces = {item.Value} }}");
            }
        }

        // Función para reemplazar vocales con tilde por su versión sin tilde
        static char QuitarTilde(char c)
        {
            switch (c)
            {
                case 'á': return 'a';
                case 'é': return 'e';
                case 'í': return 'i';
                case 'ó': return 'o';
                case 'ú': return 'u';
                case 'ü': return 'u';
                default: return c; // Si no tiene tilde, se devuelve igual
            }
        }
    }
}