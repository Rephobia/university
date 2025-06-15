using System;
using System.Collections.Generic;

class Program
{
    static List<int>[] graph;
    static bool[] visited;

    static void Main()
    {
        Console.Write("Введите количество вершин: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Введите количество рёбер: ");
        int m = int.Parse(Console.ReadLine());

        graph = new List<int>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();

        Console.WriteLine("Введите рёбра (по 2 вершины в строке):");
        for (int i = 0; i < m; i++)
        {
            string[] input = Console.ReadLine().Split();
            int u = int.Parse(input[0]);
            int v = int.Parse(input[1]);
            graph[u].Add(v);
            graph[v].Add(u);
        }

        visited = new bool[n];
        int components = 0;

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                DFS(i);
                components++;
            }
        }

        Console.WriteLine($"Число компонент связности: {components}");
    }

    static void DFS(int v)
    {
        visited[v] = true;
        foreach (int neighbor in graph[v])
        {
            if (!visited[neighbor])
                DFS(neighbor);
        }
    }
}
