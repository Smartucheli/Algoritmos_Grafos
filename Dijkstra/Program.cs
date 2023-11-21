using System;

class Program {
    static void Main(string[] args){
        Grafo novo_grafo = new Grafo(5);


        novo_grafo.adicionar_aresta(0, 1, 2);
        novo_grafo.adicionar_aresta(0, 2, 3);
        novo_grafo.adicionar_aresta(1, 2, 2);

        novo_grafo.mostra_aresta();
    }
}