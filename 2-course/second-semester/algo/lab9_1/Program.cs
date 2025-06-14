class Program
{
    static void Main(string[] args)
    {
        List<(int, int)> edges = new List<(int, int)>
            {
                (1, 2),
                (1, 3),
                (2, 4),
                (3, 4),
                (4, 5),
                (5, 6)
            };

        var graph = BuildGraph(edges);

        Console.WriteLine("Введите стартовую вершину для BFS:");
        int start = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Порядок обхода в ширину:");
        BFS(graph, start);
    }

    static Dictionary<int, List<int>> BuildGraph(List<(int, int)> edges)
    {
        var graph = new Dictionary<int, List<int>>();

        foreach (var (u, v) in edges)
        {
            if (!graph.ContainsKey(u))
                graph[u] = new List<int>();
            if (!graph.ContainsKey(v))
                graph[v] = new List<int>();

            graph[u].Add(v);
            graph[v].Add(u);
        }

        return graph;
    }

    static void BFS(Dictionary<int, List<int>> graph, int start)
    {
        var visited = new HashSet<int>();
        var queue = new Queue<int>();

        visited.Add(start);
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            Console.Write(current + " ");

            foreach (var neighbor in graph[current])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
}