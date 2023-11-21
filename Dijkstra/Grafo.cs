using System;
using System.Collections.Generic;

public class Grafo {
    // Número de vertices, se lista de arestas adjacentes
    private int V;
    private List<Tuple<int, int>>[] adj;

    // construtor que tem como parametro número de vertices do grafo
    public Grafo(int verts){
        V = verts;
        adj = new List<Tuple<int, int>>[V];
        for (int i = 0; i < V; i++ ){
            adj[i] = new List<Tuple<int, int>>();
        }
    }
    
    // função que adiciona as arestas no grafo (Direcional)
    public void adicionar_aresta(int origem, int destino, int peso){
        adj[origem].Add(new Tuple<int, int>(destino, peso));
    }
    
    // Função que imprime as arestas na tela
    public void mostra_aresta() {
        for (int i = 0; i < V; i++){
            Console.Write("Vertice " + V + " É vizinho de: ");
            foreach (var item in adj[i]){
                Console.Write(item.Item1 + "(" + item.Item2 + ") ");
            }
            Console.WriteLine();
        }
    }   
}