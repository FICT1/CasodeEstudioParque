using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaArbol.Clases
{
    public class Graph
    {
        public class Conexion
        {
            public string Destino;
            public int Distancia;
        }

        private Dictionary<string, List<Conexion>> grafo =
            new Dictionary<string, List<Conexion>>();

        public void AgregarNodo(string nombre)
        {
            if (!grafo.ContainsKey(nombre))
                grafo[nombre] = new List<Conexion>();
        }

        public void AgregarConexion(string desde, string hasta, int distancia)
        {
            AgregarNodo(desde);
            AgregarNodo(hasta);

            grafo[desde].Add(new Conexion { Destino = hasta, Distancia = distancia });
            grafo[hasta].Add(new Conexion { Destino = desde, Distancia = distancia });
        }

        public List<Conexion> ObtenerConexiones(string nodo)
        {
            if (grafo.ContainsKey(nodo))
                return grafo[nodo];

            return new List<Conexion>();
        }

     
        public bool EsConexo()
        {
            if (grafo.Count == 0)
                return true;

            var visitados = new HashSet<string>();
            string inicio = null;

            foreach (var v in grafo.Keys)
            {
                inicio = v;
                break;
            }

            DFS(inicio, visitados);

            return visitados.Count == grafo.Count;
        }

        private void DFS(string actual, HashSet<string> visitados)
        {
            visitados.Add(actual);

            foreach (var c in grafo[actual])
            {
                if (!visitados.Contains(c.Destino))
                    DFS(c.Destino, visitados);
            }
        }

        public List<string> RutaMasCorta(string inicio, string fin)
        {
            var visitados = new HashSet<string>();
            var padre = new Dictionary<string, string>();
            var cola = new Queue<string>();

            cola.Enqueue(inicio);
            visitados.Add(inicio);

            while (cola.Count > 0)
            {
                string actual = cola.Dequeue();

                if (actual == fin)
                    break;

                foreach (var c in grafo[actual])
                {
                    if (!visitados.Contains(c.Destino))
                    {
                        visitados.Add(c.Destino);
                        padre[c.Destino] = actual;
                        cola.Enqueue(c.Destino);
                    }
                }
            }

            // reconstruir camino
            var ruta = new List<string>();
            string nodo = fin;

            if (!padre.ContainsKey(fin) && inicio != fin)
                return ruta; // no existe ruta

            ruta.Add(nodo);

            while (nodo != inicio)
            {
                nodo = padre[nodo];
                ruta.Add(nodo);
            }

            ruta.Reverse();
            return ruta;
        }
    }

}

