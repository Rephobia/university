using System;
using System.Collections.Generic;

class EdmondsKarp
{
    private int vertices;
    private int[,] capacity;
    private int[,] originalCapacity;
    private List<int>[] adj;

    public EdmondsKarp(int n)
    {
        vertices = n;
        capacity = new int[n, n];
        originalCapacity = new int[n, n];
        adj = new List<int>[n];
        for (int i = 0; i < n; i++)
            adj[i] = new List<int>();
    }

    public void AddEdge(int from, int to, int cap)
    {
        capacity[from, to] = cap;
        originalCapacity[from, to] = cap;
        adj[from].Add(to);
        adj[to].Add(from);
    }

    public void PrintGraph()
    {
        Console.WriteLine("Исходный граф (ребро: пропускная способность):");
        for (int u = 0; u < vertices; u++)
        {
            foreach (int v in adj[u])
            {
                if (originalCapacity[u, v] > 0)
                    Console.WriteLine($"{u} -> {v} : {originalCapacity[u, v]}");
            }
        }
    }

    private int BFS(int s, int t, int[] parent)
    {
        Array.Fill(parent, -1);
        parent[s] = -2;
        Queue<(int vertex, int flow)> queue = new Queue<(int, int)>();
        queue.Enqueue((s, int.MaxValue));

        while (queue.Count > 0)
        {
            var (current, flow) = queue.Dequeue();
            foreach (int next in adj[current])
            {
                if (parent[next] == -1 && capacity[current, next] > 0)
                {
                    parent[next] = current;
                    int new_flow = Math.Min(flow, capacity[current, next]);
                    if (next == t)
                        return new_flow;
                    queue.Enqueue((next, new_flow));
                }
            }
        }
        return 0;
    }

    public int MaxFlow(int s, int t)
    {
        int flow = 0;
        int[] parent = new int[vertices];
        int new_flow;

        while ((new_flow = BFS(s, t, parent)) != 0)
        {
            flow += new_flow;
            int current = t;
            while (current != s)
            {
                int prev = parent[current];
                capacity[prev, current] -= new_flow;
                capacity[current, prev] += new_flow;
                current = prev;
            }
        }
        return flow;
    }
}

class Program
{
    static void Main()
    {
        // Граф из 6 вершин
        int n = 6;
        EdmondsKarp graph = new EdmondsKarp(n);

        graph.AddEdge(0, 1, 16);
        graph.AddEdge(0, 2, 13);
        graph.AddEdge(1, 2, 10);
        graph.AddEdge(2, 1, 4);
        graph.AddEdge(1, 3, 12);
        graph.AddEdge(3, 2, 9);
        graph.AddEdge(2, 4, 14);
        graph.AddEdge(4, 3, 7);
        graph.AddEdge(3, 5, 20);
        graph.AddEdge(4, 5, 4);

        int source = 0;
        int sink = 5;

        graph.PrintGraph();

        int maxFlow = graph.MaxFlow(source, sink);
        Console.WriteLine($"\nМаксимальный поток из {source} в {sink}: {maxFlow}");
    }
}
