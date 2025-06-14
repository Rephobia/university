using System;

class Program
{
    static void Main()
    {
        // Матрица смежности графа (0 - отсутствие ребра, положительное число - вес ребра)
        int[,] graph = {
            { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
            { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
            { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
            { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
            { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
            { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
            { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
            { 0, 0, 2, 0, 0, 0, 6, 7, 0 }
        };

        Console.WriteLine("Введите стартовую вершину (0-8):");
        int start = int.Parse(Console.ReadLine()!);

        Dijkstra(graph, start);
    }

    static void Dijkstra(int[,] graph, int start)
    {
        int n = graph.GetLength(0);
        int[] dist = new int[n];       
        bool[] visited = new bool[n];

        const int INF = int.MaxValue;

        for (int i = 0; i < n; i++)
            dist[i] = INF;
        dist[start] = 0;

        for (int count = 0; count < n - 1; count++)
        {
            int u = MinDistance(dist, visited);
            if (u == -1) break;

            visited[u] = true;

            for (int v = 0; v < n; v++)
            {
                if (!visited[v] && graph[u, v] != 0 && dist[u] != INF &&
                    dist[u] + graph[u, v] < dist[v])
                {
                    dist[v] = dist[u] + graph[u, v];
                }
            }
        }

        Console.WriteLine("Вершина\tРасстояние от начальной вершины");
        for (int i = 0; i < n; i++)
        {
            if (dist[i] == INF)
                Console.WriteLine($"{i}\t\tНет пути");
            else
                Console.WriteLine($"{i}\t\t{dist[i]}");
        }
    }
    static int MinDistance(int[] dist, bool[] visited)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < dist.Length; v++)
        {
            if (!visited[v] && dist[v] <= min)
            {
                min = dist[v];
                minIndex = v;
            }
        }

        return minIndex;
    }
}
