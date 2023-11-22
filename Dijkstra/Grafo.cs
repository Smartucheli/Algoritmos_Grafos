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
            Console.Write("Vertice " + i + " É vizinho de: ");
            foreach (var item in adj[i]){
                Console.Write(item.Item1 + "(" + item.Item2 + ") ");
            }
            Console.WriteLine();
        }
    }   

    public void dijkstra(int origem) {
        // armazena distancia minima e se foi visitado 
        int[] distancias = new int[V];
        bool[] visitado = new bool[V];

        // Deixando todos os caminhos como infinito e todos os vertices como não visitado
        for (int i = 0; i < V; i++){
            distancias[i] = int.MaxValue;
            visitado[i] = false;
        }

        distancias[origem] = 0;

        for (int j = 0; j < V; j++) {
            int vertice_visitado = menor_distancia(distancias, visitado);
            visitado[vertice_visitado] = true;


            foreach (var vizinho in adj[vertice_visitado]){
                int indice = vizinho.Item1;
                int peso = vizinho.Item2;

                // aplica logica do algoritmo de fato
                if (!visitado[indice] && distancias[vertice_visitado] != int.MaxValue && distancias[vertice_visitado] + peso < distancias[indice]){
                    distancias[indice] = distancias[vertice_visitado] + peso;
                }
            }
        }

        Console.WriteLine("Distância do vértice de origem " + origem + " para todos os vértices:");
        for (int i = 0; i < V; i++) {
            Console.WriteLine("Para o vértice " + i + ": " + distancias[i]);
        }


    }

    // função para encontrar o proximo vertice com menor distancia possivel
    public int menor_distancia(int[] distancias, bool[] visitado){
        int min = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; V < V; V++){
            if (visitado[v] == false && distancias[v] <= min) {
                min = distancias[v];
                minIndex = v;
            }
        }

        return minIndex;

    }

}