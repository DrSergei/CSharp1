class Task3
{
    static Int32 BFS(Boolean[,] graph, Int32 start, Int32 end)
    {
        var n = graph.GetLength(0);
        var used = new Boolean[n];
        var queue = new Queue<(Int32 node, Int32 depth)>();
        queue.Enqueue((start, 0));

        while (queue.Count > 0)
        {
            var (node, depth) = queue.Dequeue();
            if (node == end)
            {
                return depth;
            }
            used[node] = true;
            for (Int32 i = 0; i < n; i++)
            {
                if (graph[node, i] && !used[i])
                {
                    queue.Enqueue((i, depth + 1));
                }
            }
        }
        return -1;
    }

    static Int32 Solve(Int32[][] routes, Int32 start, Int32 end)
    {
        var n = routes.Length;
        var graph = new Boolean[n + 2, n + 2];
        var nodes = routes.Select(r => r.ToHashSet()).ToArray();
        for (Int32 i = 0; i < n; i++)
        {
            for (Int32 j = 0; j < n; j++)
            {
                if (i != j)
                {
                    if (nodes[i].Intersect(nodes[j]).Count() > 0)
                    {
                        graph[i, j] = true;
                    }
                }
            }
        }
        for (Int32 i = 0; i < n; i++)
        {
            if (nodes[i].Contains(start))
            {
                graph[i, n] = true;
                graph[n, i] = true;
            }
            if (nodes[i].Contains(end))
            {
                graph[i, n + 1] = true;
                graph[n + 1, i] = true;
            }
        }

        var res = BFS(graph, n, n + 1);
        return (res == -1) ? -1 : (res - 1);
    }

    static void Main()
    {
        Console.WriteLine(Solve(new Int32[][] { new int[] { 1, 2, 7 }, new int[] { 3, 6, 7 } }, 1, 6));
        Console.WriteLine(Solve(new Int32[][] { new int[] { 7, 12 }, new int[] { 4, 5, 15 }, new int[] { 6 }, new int[] { 15, 19 }, new int[] { 9, 12, 13 } }, 15, 12));
    }
}
