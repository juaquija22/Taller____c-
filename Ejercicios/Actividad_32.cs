using System;
using System.Collections.Generic;

namespace Taller____c_.Ejercicios
{
    public class SistemaRutas
    {
        static Dictionary<string, Dictionary<string, int>> grafo =
            new Dictionary<string, Dictionary<string, int>>();

        public static void Ejecutar()
        {
            CargarGrafo();

            Console.Write("Punto de recogida: ");
            string inicio = (Console.ReadLine() ?? "").Trim().ToUpper();

            Console.Write("Punto de entrega: ");
            string destino = (Console.ReadLine() ?? "").Trim().ToUpper();

            // Validación para evitar error
            if (!grafo.ContainsKey(inicio) || !grafo.ContainsKey(destino))
            {
                Console.WriteLine("\nUno o ambos puntos no existen.");
                Console.WriteLine("Puntos disponibles: " + string.Join(", ", grafo.Keys));
                Console.ReadKey();
                return;
            }

            var resultado = Dijkstra(inicio, destino);

            if (resultado.distancia == int.MaxValue)
            {
                Console.WriteLine("\nNo existe ruta entre los puntos.");
            }
            else
            {
                Console.WriteLine("\nRuta de menor consumo:");
                Console.WriteLine(string.Join(" -> ", resultado.ruta));
                Console.WriteLine($"Consumo total estimado: {resultado.distancia}");
            }

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // ─────────────────────────────────────
        // Grafo
        static void CargarGrafo()
        {
            grafo.Clear();

            AgregarArista("A", "B", 4);
            AgregarArista("A", "C", 2);
            AgregarArista("B", "D", 5);
            AgregarArista("C", "B", 1);
            AgregarArista("C", "D", 8);
            AgregarArista("C", "E", 10);
            AgregarArista("D", "E", 2);
            AgregarArista("E", "F", 3);
            AgregarArista("D", "F", 6);
        }

        static void AgregarArista(string origen, string destino, int costo)
        {
            if (!grafo.ContainsKey(origen))
                grafo[origen] = new Dictionary<string, int>();

            grafo[origen][destino] = costo;
        }

        // ─────────────────────────────────────
        // DIJKSTRA
        static (int distancia, List<string> ruta) Dijkstra(string inicio, string destino)
        {
            var distancias = new Dictionary<string, int>();
            var previos = new Dictionary<string, string>();
            var visitados = new HashSet<string>();

            foreach (var nodo in grafo.Keys)
                distancias[nodo] = int.MaxValue;

            distancias[inicio] = 0;

            while (visitados.Count < grafo.Count)
            {
                string? actual = null;
                int menor = int.MaxValue;

                foreach (var nodo in distancias)
                {
                    if (!visitados.Contains(nodo.Key) && nodo.Value < menor)
                    {
                        menor = nodo.Value;
                        actual = nodo.Key;
                    }
                }

                if (actual == null)
                    break;

                visitados.Add(actual);

                foreach (var vecino in grafo[actual])
                {
                    int nuevaDist = distancias[actual] + vecino.Value;

                    if (nuevaDist < distancias.GetValueOrDefault(vecino.Key, int.MaxValue))
                    {
                        distancias[vecino.Key] = nuevaDist;
                        previos[vecino.Key] = actual;
                    }
                }
            }

            // Reconstruir ruta
            List<string> ruta = new List<string>();
            string nodoActual = destino;

            while (nodoActual != null && previos.ContainsKey(nodoActual))
            {
                ruta.Insert(0, nodoActual);
                nodoActual = previos[nodoActual];
            }

            if (nodoActual == inicio)
                ruta.Insert(0, inicio);

            return (distancias.GetValueOrDefault(destino, int.MaxValue), ruta);
        }
    }
}