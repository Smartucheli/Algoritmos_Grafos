using System;

class Program {
    static void Main(string[] args){
        Grafo novo_grafo = new Grafo(5);


        

        novo_grafo.mostra_aresta();
        
        novo_grafo.dijkstra(2);
    }
}