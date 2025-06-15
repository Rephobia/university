using System;
using System.Collections.Generic;

class Graph
{
    private int V;
    private List<int>[] adj;
    private int time = 0;

    public Graph(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; i++)
            adj[i] = new List<int>();
    }

    public void AddEdge(int u, int v)
    {
        adj[u].Add(v);
        adj[v].Add(u);
    }

    public void FindArticulationPointsAndBridges()
    {
        bool[] visited = new bool[V];
        int[] disc = new int[V];
        int[] low = new int[V];
        int[] parent = new int[V];
        bool[] isArticulation = new bool[V];

        for (int i = 0; i < V; i++)
        {
            parent[i] = -1;
            visited[i] = false;
        }

        for (int i = 0; i < V; i++)
        {
            if (!visited[i])
                DFS(i, visited, disc, low, parent, isArticulation);
        }

        Console.WriteLine("\nТочки сочленения:");
        for (int i = 0; i < V; i++)
            if (isArticulation[i])
                Console.WriteLine($"Вершина {i}");

    }

    private void DFS(int u, bool[] visited, int[] disc, int[] low, int[] parent, bool[] isArticulation)
    {
        visited[u] = true;
        disc[u] = low[u] = ++time;
        int children = 0;

        foreach (int v in adj[u])
        {
            if (!visited[v])
            {
                children++;
                parent[v] = u;
                DFS(v, visited, disc, low, parent, isArticulation);

                low[u] = Math.Min(low[u], low[v]);

                if (parent[u] == -1 && children > 1)
                    isArticulation[u] = true;

                if (parent[u] != -1 && low[v] >= disc[u])
                    isArticulation[u] = true;

                if (low[v] > disc[u])
                    Console.WriteLine($"Мост между вершинами {u} и {v}");
            }
            else if (v != parent[u])
            {
                low[u] = Math.Min(low[u], disc[v]);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите количество вершин: ");
        int V = int.Parse(Console.ReadLine());

        Console.Write("Введите количество рёбер: ");
        int E = int.Parse(Console.ReadLine());

        Graph g = new Graph(V);

        Console.WriteLine("Введите рёбра (две вершины через пробел, от 0 до V-1):");
        for (int i = 0; i < E; i++)
        {
            var input = Console.ReadLine().Split();
            int u = int.Parse(input[0]);
            int v = int.Parse(input[1]);
            g.AddEdge(u, v);
        }

        g.FindArticulationPointsAndBridges();
    }
}
