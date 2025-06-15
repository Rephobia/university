using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество вершин: ");
        int vertices = int.Parse(Console.ReadLine());

        Console.Write("Введите количество рёбер: ");
        int edges = int.Parse(Console.ReadLine());

        List<int>[] graph = new List<int>[vertices];
        int[] inDegree = new int[vertices];

        for (int i = 0; i < vertices; i++)
            graph[i] = new List<int>();

        Console.WriteLine("Введите рёбра (по 2 вершины на строке):");

        for (int i = 0; i < edges; i++)
        {
            string[] input = Console.ReadLine().Split();
            int from = int.Parse(input[0]);
            int to = int.Parse(input[1]);
            graph[from].Add(to);
            inDegree[to]++;
        }

        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < vertices; i++)
        {
            if (inDegree[i] == 0)
                queue.Enqueue(i);
        }

        int visitedCount = 0;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            visitedCount++;

            foreach (var neighbor in graph[current])
            {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0)
                    queue.Enqueue(neighbor);
            }
        }

        if (visitedCount == vertices)
            Console.WriteLine("Цикл не найден.");
        else
            Console.WriteLine("Цикл найден!");
    }
}
