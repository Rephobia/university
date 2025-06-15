using System;
using System.Collections.Generic;
using System.Linq;

class Graph
{
    private int V;
    private bool[,] adj;

    public Graph(int vertices)
    {
        V = vertices;
        adj = new bool[V, V];
    }

    public void AddEdge(int u, int v)
    {
        adj[u, v] = true;
        adj[v, u] = true; // Неориентированный граф
    }

    public void PrintGraph()
    {
        Console.WriteLine("Матрица смежности графа:");
        for (int i = 0; i < V; i++)
        {
            for (int j = 0; j < V; j++)
                Console.Write((adj[i, j] ? "1 " : "0 "));
            Console.WriteLine();
        }
    }

    public bool FindHamiltonianCycle()
    {
        var path = new List<int> { 0 };
        var visited = new bool[V];
        visited[0] = true;

        if (HamiltonianDFS(0, path, visited))
        {
            Console.WriteLine("\nНайден Гамильтонов цикл:");
            Console.WriteLine(string.Join(" → ", path) + " → " + path[0]);
            return true;
        }
        else
        {
            Console.WriteLine("\nГамильтонов цикл не найден.");
            return false;
        }
    }

    private bool HamiltonianDFS(int current, List<int> path, bool[] visited)
    {
        if (path.Count == V)
            return adj[current, path[0]]; // проверка возможности замкнуть цикл

        for (int next = 0; next < V; next++)
        {
            if (adj[current, next] && !visited[next])
            {
                visited[next] = true;
                path.Add(next);

                if (HamiltonianDFS(next, path, visited))
                    return true;

                visited[next] = false;
                path.RemoveAt(path.Count - 1); // откат
            }
        }

        return false;
    }
}

class Program
{
    static void Main()
    {
        Graph graph = new Graph(4);
        graph.AddEdge(0, 1);
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 3);
        graph.AddEdge(3, 0);
        graph.AddEdge(1, 3);
        graph.AddEdge(0, 2);

        graph.PrintGraph();
        graph.FindHamiltonianCycle();
    }
}
