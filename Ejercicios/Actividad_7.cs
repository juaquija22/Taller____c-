using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class SimbolosEquilibrados
    {
        public static void Ejecutar()
        {
            // Pedimos la expresión
            Console.WriteLine("Ingrese una expresión:");
            string texto = Console.ReadLine() ?? "";

            int resultado = SimbEquilibrados(texto);

            Console.WriteLine(resultado);
        }

        static int SimbEquilibrados(string texto)
        {
            // Pila para guardar símbolos de apertura
            Stack<char> pila = new Stack<char>();

            // Recorremos la cadena
            for (int i = 0; i < texto.Length; i++)
            {
                char c = texto[i];

                // Si es símbolo de apertura, lo guardamos
                if (c == '(' || c == '[' || c == '{')
                {
                    pila.Push(c);
                }
                // Si es símbolo de cierre
                else if (c == ')' || c == ']' || c == '}')
                {
                    // Si la pila está vacía → error
                    if (pila.Count == 0)
                        return i;

                    // Sacamos el último símbolo abierto
                    char ultimo = pila.Pop();

                    // Verificamos si coinciden
                    if (!Coinciden(ultimo, c))
                        return i;
                }
            }

            // Si al final quedan símbolos sin cerrar → error
            if (pila.Count > 0)
                return texto.Length;

            // Todo correcto
            return -1;
        }

        // Función que valida si apertura y cierre coinciden
        static bool Coinciden(char apertura, char cierre)
        {
            return (apertura == '(' && cierre == ')') ||
                   (apertura == '[' && cierre == ']') ||
                   (apertura == '{' && cierre == '}');
        }
    }
}
