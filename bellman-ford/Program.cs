using System;

namespace Program
{
    class Program 
    {   
        static void Main(string[] args)
        {
        
        BellmanFord.Grafo grafo = new BellmanFord.Grafo(5, 6);

        grafo.Adiciona_aresta(0, 1, -1);
        grafo.Adiciona_aresta(0, 2, 4);
        grafo.Adiciona_aresta(1, 2, 3);
        grafo.Adiciona_aresta(1, 3, 2);
        grafo.Adiciona_aresta(1, 4, 2);
        grafo.Adiciona_aresta(3, 2, 5);
        grafo.Adiciona_aresta(3, 1, 1);
        grafo.Adiciona_aresta(4, 3, -3);

        int verticeParaVerificar = 0;

        if (grafo.ciclo_negativo(verticeParaVerificar))
        {
            Console.WriteLine("Tem ciclo negativo");
        }
        else
        {
            Console.WriteLine("Não tem ciclo negativo");
        }

        // Imprimir o caminho mais curto do vértice 0 ao vértice 2 (por exemplo)
        int origem = 0;
        int destino = 4;

        grafo.ImprimirCaminho(origem, destino);
        }
    }
}