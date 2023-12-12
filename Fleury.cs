namespace Fleury2
{
    internal class Program
    {
        class Grafo
        {
            private int vertices;
            private List<int>[] adjacencias;

            public Grafo(int v)
            {
                vertices = v;
                adjacencias = new List<int>[v];
                for (int i = 0; i < v; ++i)
                    adjacencias[i] = new List<int>();
            }

            public void AdicionarAresta(int v1, int v2)
            {
                // Adiciona uma aresta entre os vértices v1 e v2
                adjacencias[v1].Add(v2);
                adjacencias[v2].Add(v1);
            }

            public void ImprimirCicloOuCaminhoEuleriano(int inicio)
            {
                if (!Euleriano())
                {
                    // Se o grafo não for Euleriano, imprime uma mensagem
                    Console.WriteLine("O grafo não possui um ciclo euleriano nem um caminho euleriano.");
                    return;
                }

                Console.WriteLine("Ciclo ou Caminho Euleriano:");
                ImprimirCicloOuCaminhoEulerianoUtil(inicio);
                Console.WriteLine();
            }

            private void ImprimirCicloOuCaminhoEulerianoUtil(int u)
            {
                Stack<int> pilha = new Stack<int>();
                pilha.Push(u);

                while (pilha.Count > 0)
                {
                    int atual = pilha.Peek();

                    // Se há arestas adjacentes, escolhe uma
                    if (adjacencias[atual].Count > 0)
                    {
                        int vizinho = adjacencias[atual][0];

                        // Remove a aresta (atual, vizinho)
                        adjacencias[atual].Remove(vizinho);
                        adjacencias[vizinho].Remove(atual);

                        // Adiciona o vizinho à pilha
                        pilha.Push(vizinho);
                    }
                    else
                    {
                        // Se não há arestas, imprime o vértice e o remove da pilha
                        Console.Write(pilha.Pop() + " -> ");
                    }
                }
            }

            private bool Euleriano()
            {
                // Verifica se todos os vértices têm grau par
                for (int i = 0; i < vertices; i++)
                {
                    if (adjacencias[i].Count % 2 != 0)
                        return false;
                }

                return true;
            }
        }
        static void Main(string[] args)
        {
            // Exemplo de uso do grafo
            Grafo grafo = new Grafo(10);

            grafo.AdicionarAresta(0, 1);
            grafo.AdicionarAresta(0, 2);
            grafo.AdicionarAresta(1, 2);
            grafo.AdicionarAresta(1, 3);
            grafo.AdicionarAresta(2, 3);
            grafo.AdicionarAresta(2, 4);
            grafo.AdicionarAresta(3, 4);
            grafo.AdicionarAresta(3, 5);
            grafo.AdicionarAresta(4, 5);
            grafo.AdicionarAresta(4, 6);
            grafo.AdicionarAresta(5, 6);
            grafo.AdicionarAresta(5, 7);
            grafo.AdicionarAresta(6, 7);
            grafo.AdicionarAresta(6, 8);
            grafo.AdicionarAresta(7, 8);
            grafo.AdicionarAresta(7, 9);
            grafo.AdicionarAresta(8, 9);
            grafo.AdicionarAresta(8, 0);
            grafo.AdicionarAresta(9, 1);
            grafo.AdicionarAresta(9, 2);

            int inicio = 0; // Pode ser qualquer vértice do grafo
            grafo.ImprimirCicloOuCaminhoEuleriano(inicio);

        }
    }
}