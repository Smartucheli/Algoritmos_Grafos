namespace buscaAlternativa
{
    internal class Program
    {
        public class Vertice
        {
            public int Valor { get; }
            public Vertice pai;
            public int TD;
            public int TT;
            public List<Vertice> Vizinhos { get; }

            public Vertice(int valor, int tD, int tT)
            {
                Valor = valor;
                Vizinhos = new List<Vertice>();
                this.pai = null;
                TD = tD;
                TT = tT;
            }

            public void AdicionarVizinho(Vertice vizinho)
            {
                if (!Vizinhos.Contains(vizinho))
                {
                    Vizinhos.Add(vizinho);
                    vizinho.Vizinhos.Add(this); // Adicionando para um grafo não direcionado
                }
            }
        }

        public class Grafo
        {
            public List<Vertice> Vertices { get; }

            public Grafo()
            {
                Vertices = new List<Vertice>();
            }

            public void AdicionarVertice(Vertice v)
            {


                if (!Vertices.Contains(v))
                {
                    Vertices.Add(v);
                }
            }

            public void ImprimirGrafo()
            {
                foreach (var vertice in Vertices)
                {
                    Console.Write($"Vertice {vertice.Valor}: ");
                    foreach (var vizinho in vertice.Vizinhos)
                    {
                        Console.Write($"{vizinho.Valor} ");
                    }
                    Console.WriteLine();
                }
            }

            public void imprimirTabela()
            {
                foreach (var vertice in Vertices)
                {
                    Console.WriteLine($"Vertice {vertice.Valor}:");
                    if (vertice.pai == null)
                    {
                        Console.WriteLine($"TD = {vertice.TD} | TT = {vertice.TT} | Pai = 0");
                        Console.WriteLine("-------------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine($"TD = {vertice.TD} | TT = {vertice.TT} | Pai = {vertice.pai.Valor}");
                        Console.WriteLine("-------------------------------------------------");
                    }

                }
            }

            public int contVizinhosTD(Vertice vertice)
            {
                int cont = 0;
                foreach (var vizinho in vertice.Vizinhos)
                {
                    if (vizinho.TD > 0)
                    {
                        cont++;
                    }
                    else
                    {
                        break;
                    }
                }

                return cont;
            }

            public void listarVizinhos(Vertice vertice)
            {
                Console.WriteLine($"Você está no vértice {vertice.Valor}. Deseja ir para qual vértice?");
                if (vertice.pai != null)
                {
                    Console.WriteLine($"TD: {vertice.TD} | Pai:{vertice.pai.Valor}");
                }

                foreach (var vizinho in vertice.Vizinhos)
                {
                    if (vizinho.TD == 0)
                    {
                        Console.Write($"{vizinho.Valor} ");
                    }
                }
            }

            public int conferirProximo(Vertice vertice)
            {
                int cont = 0;
                foreach (var prox in vertice.Vizinhos)
                {
                    if (prox.TD == 0) // Essa verificação pra encontrar o vértice solicitado pelo usuário.
                    {
                        return cont;
                    }
                    cont++;
                }
                return cont;
            }


            public void buscaProfundidade(Vertice vertice, ref int t, Vertice pai)
            {
                vertice.TD = t;
                t++;
                vertice.pai = pai;

                if (contVizinhosTD(vertice) == (vertice.Vizinhos).Count)
                {
                    vertice.TT = t;
                    return;
                }

                buscaProfundidade(vertice.Vizinhos[conferirProximo(vertice)], ref t, vertice);

                t++;
                if (contVizinhosTD(vertice) != (vertice.Vizinhos).Count) // Essa verificação pra encontrar o vértice solicitado pelo usuário depois da recursividade retornar.
                {
                    buscaProfundidade(vertice.Vizinhos[conferirProximo(vertice)], ref t, vertice);
                    t++;
                    if (contVizinhosTD(vertice) == (vertice.Vizinhos).Count)
                    {
                        vertice.TT = t;
                        return;
                    }
                }
                else
                {
                    vertice.TT = t;
                    return;
                }

            }
        }




        static void Main(string[] args)
        {
            Grafo meuGrafo = new Grafo();

            Vertice v1 = new Vertice(1, 0, 0);
            Vertice v2 = new Vertice(2, 0, 0);
            Vertice v3 = new Vertice(3, 0, 0);
            Vertice v4 = new Vertice(4, 0, 0);
            Vertice v5 = new Vertice(5, 0, 0);
            Vertice v6 = new Vertice(6, 0, 0);
            Vertice v7 = new Vertice(7, 0, 0);
            Vertice v8 = new Vertice(8, 0, 0);
            Vertice v9 = new Vertice(9, 0, 0);
            Vertice v10 = new Vertice(10, 0, 0);

            meuGrafo.AdicionarVertice(v1);
            meuGrafo.AdicionarVertice(v2);
            meuGrafo.AdicionarVertice(v3);
            meuGrafo.AdicionarVertice(v4);
            meuGrafo.AdicionarVertice(v5);
            meuGrafo.AdicionarVertice(v6);
            meuGrafo.AdicionarVertice(v7);
            meuGrafo.AdicionarVertice(v8);
            meuGrafo.AdicionarVertice(v9);
            meuGrafo.AdicionarVertice(v10);

            v1.AdicionarVizinho(v5);
            v1.AdicionarVizinho(v6);
            v1.AdicionarVizinho(v7);
            v1.AdicionarVizinho(v8);
            v1.AdicionarVizinho(v9);
            v1.AdicionarVizinho(v10);

            v2.AdicionarVizinho(v3);
            v2.AdicionarVizinho(v4);
            v2.AdicionarVizinho(v6);
            v2.AdicionarVizinho(v10);

            v3.AdicionarVizinho(v4);
            v3.AdicionarVizinho(v5);
            v3.AdicionarVizinho(v9);

            v4.AdicionarVizinho(v5);
            v4.AdicionarVizinho(v6);

            v5.AdicionarVizinho(v6);

            v6.AdicionarVizinho(v7);

            v7.AdicionarVizinho(v8);

            v8.AdicionarVizinho(v9);

            v9.AdicionarVizinho(v10);



            int t = 1;
            meuGrafo.buscaProfundidade(v1, ref t, null);

            meuGrafo.imprimirTabela();


        }
    }
}