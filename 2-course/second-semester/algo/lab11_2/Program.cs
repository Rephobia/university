using System;
using System.Collections.Generic;

class Graph
{
    private Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();

    public void AddEdge(int u, int v)
    {
        if (!adjacencyList.ContainsKey(u))
            adjacencyList[u] = new List<int>();
        if (!adjacencyList.ContainsKey(v))
            adjacencyList[v] = new List<int>();

        adjacencyList[u].Add(v);
        adjacencyList[v].Add(u);
    }

    public void PrintGraph()
    {
        Console.WriteLine("Список смежности графа:");
        foreach (var pair in adjacencyList)
        {
            Console.Write($"{pair.Key}: ");
            foreach (var neighbor in pair.Value)
                Console.Write($"{neighbor} ");
            Console.WriteLine();
        }
    }

    public bool HasEulerianCycle()
    {
        foreach (var kvp in adjacencyList)
        {
            if (kvp.Value.Count % 2 != 0)
                return false;
        }
        return true;
    }

    public List<int> FindEulerianCycle()
    {
        var stack = new Stack<int>();
        var cycle = new List<int>();

        // Глубокая копия графа
        var localGraph = new Dictionary<int, List<int>>();
        foreach (var kvp in adjacencyList)
            localGraph[kvp.Key] = new List<int>(kvp.Value);

        int current = GetStartVertex();
        stack.Push(current);

        while (stack.Count > 0)
        {
            if (localGraph[current].Count > 0)
            {
                stack.Push(current);
                int next = localGraph[current][0];
                localGraph[current].Remove(next);
                localGraph[next].Remove(current);
                current = next;
            }
            else
            {
                cycle.Add(current);
                current = stack.Pop();
            }
        }

        cycle.Reverse();
        return cycle;
    }

    private int GetStartVertex()
    {
        foreach (var kvp in adjacencyList)
            return kvp.Key;
        return 0;
    }
}

class Program
{
    static void Main()
    {
        var graph = new Graph();

        graph.AddEdge(0, 1);
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 0);
        graph.AddEdge(0, 3);
        graph.AddEdge(3, 4);
        graph.AddEdge(4, 0);

        graph.PrintGraph();

        if (!graph.HasEulerianCycle())
        {
            Console.WriteLine("\nЭйлеров цикл невозможен: не все вершины имеют чётную степень.");
        }
        else
        {
            var cycle = graph.FindEulerianCycle();
            Console.WriteLine("\nЭйлеров цикл:");
            Console.WriteLine(string.Join(" → ", cycle));
        }
    }
}
