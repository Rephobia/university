using System;
using System.Collections.Generic;

class Program
{
    static int n, m;
    static List<int>[] graph;
    static int[] match;
    static bool[] used;

    static void Main()
    {
        Console.Write("Введите количество вершин в левой доле (L): ");
        n = int.Parse(Console.ReadLine());

        Console.Write("Введите количество вершин в правой доле (R): ");
        m = int.Parse(Console.ReadLine());

        Console.Write("Введите количество рёбер: ");
        int e = int.Parse(Console.ReadLine());

        graph = new List<int>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();

        Console.WriteLine("Введите рёбра (формат: левый правый):");
        for (int i = 0; i < e; i++)
        {
            var parts = Console.ReadLine().Split();
            int u = int.Parse(parts[0]);
            int v = int.Parse(parts[1]);
            graph[u].Add(v);
        }

        match = new int[m];
        for (int i = 0; i < m; i++) match[i] = -1;

        int result = 0;
        for (int v = 0; v < n; v++)
        {
            used = new bool[n];
            if (TryKuhn(v))
                result++;
        }

        Console.WriteLine($"\nНаибольшее паросочетание: {result}");
        for (int i = 0; i < m; i++)
        {
            if (match[i] != -1)
                Console.WriteLine($"L[{match[i]}] <-> R[{i}]");
        }
    }

    static bool TryKuhn(int v)
    {
        if (used[v]) return false;
        used[v] = true;

        foreach (int u in graph[v])
        {
            if (match[u] == -1 || TryKuhn(match[u]))
            {
                match[u] = v;
                return true;
            }
        }

        return false;
    }
}
