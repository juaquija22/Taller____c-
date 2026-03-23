using System;
using System.Collections;

namespace Taller____c_.Ejercicios
{
    public class ArrayListMixto
    {
        public static void Ejecutar()
        {
            // Creamos un ArrayList con distintos tipos
            ArrayList datos = new ArrayList();

            datos.Add("Juan");   // string
            datos.Add(25);       // int
            datos.Add(1.75);     // double
            datos.Add(true);     // bool

            Console.WriteLine("Elementos del ArrayList:\n");

            // Recorremos la colección
            foreach (var item in datos)
            {
                // Mostramos el valor y su tipo de dato
                Console.WriteLine($"Valor: {item} | Tipo: {item.GetType()}");
            }

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}