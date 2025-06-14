using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[,] adjacencyMatrix = {
            {0, 1, 0, 1, 0},
            {1, 0, 1, 1, 0},
            {0, 1, 0, 0, 1},
            {1, 1, 0, 0, 1},
            {0, 0, 1, 1, 0}
        };

        Console.WriteLine("Матрица смежности:");
        PrintMatrix(adjacencyMatrix);

        int[,] incidenceMatrix = BuildIncidenceMatrix(adjacencyMatrix);

        Console.WriteLine("\nМатрица инцидентности:");
        PrintMatrix(incidenceMatrix);

        Console.WriteLine("\nВведите стартовую вершину (0-" + (adjacencyMatrix.GetLength(0) - 1) + "):");
        int start = int.Parse(Console.ReadLine()!);

        Console.WriteLine("\nРезультат поиска в ширину (BFS):");
        BFS(adjacencyMatrix, start);
    }

    static int[,] BuildIncidenceMatrix(int[,] adjacency)
    {
        int n = adjacency.GetLength(0);
        var edges = new List<(int, int)>();

        for (int i = 0; i < n; i++)
            for (int j = i + 1; j < n; j++)
                if (adjacency[i, j] == 1)
                    edges.Add((i, j));

        int m = edges.Count;
        int[,] incidence = new int[n, m];

        for (int e = 0; e < m; e++)
        {
            var (u, v) = edges[e];
            incidence[u, e] = 1;
            incidence[v, e] = 1;
        }

        return incidence;
    }

    static void BFS(int[,] adjacency, int start)
    {
        int n = adjacency.GetLength(0);
        bool[] visited = new bool[n];
        Queue<int> queue = new Queue<int>();

        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            Console.Write(current + " ");

            for (int i = 0; i < n; i++)
            {
                if (adjacency[current, i] == 1 && !visited[i])
                {
                    visited[i] = true;
                    queue.Enqueue(i);
                }
            }
        }
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }
}
