public class BellmanFord
{
    public class Aresta
    {
        public int vertice, destino, peso;
    }

    public class Grafo
    {
        public int V, E;
        public List<Aresta> aresta;
        public int[] predecessores; // Vetor para armazenar os predecessores

        public Grafo(int V, int E)
        {
            this.V = V;
            this.E = E;
            this.aresta = new List<Aresta>();
            this.predecessores = new int[V];
        }

        public void Adiciona_aresta(int vertice, int destino, int peso)
        {
            Aresta nova_aresta = new Aresta { destino = destino, vertice = vertice, peso = peso };
            aresta.Add(nova_aresta);
        }

        public bool ciclo_negativo(int vertice)
        {
            int[] destino = new int[V];
            Array.Fill(destino, int.MaxValue);
            Array.Fill(predecessores, -1); // Inicializa os predecessores como -1
            destino[vertice] = 0;

            for (int i = 0; i < V - 1; i++)
            {
                foreach (var aresta in this.aresta)
                {
                    int u = aresta.vertice;
                    int v = aresta.destino;
                    int peso = aresta.peso;

                    if (destino[u] != int.MaxValue && destino[u] + peso < destino[v])
                    {
                        destino[v] = destino[u] + peso;
                        predecessores[v] = u; // Atualiza o predecessor
                    }
                }
            }

            // Verifica ciclos negativos
            foreach (var aresta in this.aresta)
            {
                int u = aresta.vertice;
                int v = aresta.destino;
                int peso = aresta.peso;

                if (destino[u] != int.MaxValue && destino[u] + peso < destino[v])
                    return true;
            }

            return false;
        }

        public void ImprimirCaminho(int origem, int destino)
        {
            Console.WriteLine($"Caminho mais curto de {origem} a {destino}:");
            List<int> caminho = ObterCaminho(origem, destino);
            if (caminho != null)
            {
                for (int i = 0; i < caminho.Count - 1; i++)
                {
                    Console.Write($"{caminho[i]} -> ");
                }
                Console.WriteLine($"{caminho[caminho.Count - 1]}");
            }
            else
            {
                Console.WriteLine("Não há caminho entre os vértices.");
            }
        }

        private List<int> ObterCaminho(int origem, int destino)
        {
            List<int> caminho = new List<int>();
            if (destino == origem)
            {
                caminho.Add(destino);
                return caminho;
            }
            if (predecessores[destino] == -1)
                return null;

            while (destino != -1)
            {
                caminho.Add(destino);
                destino = predecessores[destino];
            }
            caminho.Reverse();
            return caminho;
        }
    }
}
