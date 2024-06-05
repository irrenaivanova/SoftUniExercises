using System;
using System.Collections.Generic;

class Program
{
    static int[][] KnightMoves = new int[][] {
        new int[] { 2, 1 },
        new int[] { 1, 2 },
        new int[] { -1, 2 },
        new int[] { -2, 1 },
        new int[] { -2, -1 },
        new int[] { -1, -2 },
        new int[] { 1, -2 },
        new int[] { 2, -1 }
    };

    static bool IsValidMove(int x, int y, int N)
    {
        return (x >= 0 && x < N && y >= 0 && y < N);
    }

    static List<int[]> FindPath(int N, int[] start, int[] end)
    {
        var queue = new Queue<int[]>();
        var visited = new bool[N, N];
        var parent = new Dictionary<int[], int[]>();

        queue.Enqueue(start);
        visited[start[0], start[1]] = true;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current[0] == end[0] && current[1] == end[1])
            {
                var path = new List<int[]>();
                var node = end;
                while (node != null)
                {
                    path.Insert(0, node);
                    node = parent.ContainsKey(node) ? parent[node] : null;
                }
                return path;
            }

            foreach (var move in KnightMoves)
            {
                int newX = current[0] + move[0];
                int newY = current[1] + move[1];
                if (IsValidMove(newX, newY, N) && !visited[newX, newY])
                {
                    queue.Enqueue(new int[] { newX, newY });
                    visited[newX, newY] = true;
                    parent[new int[] { newX, newY }] = current;
                }
            }
        }

        return null; // No path found
    }

    static void Main(string[] args)
    {
        
        int colF = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine()); 
        int[] start = { int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()) }; // Starting position
        int[] end = { int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()) }; // Ending position

        var path = FindPath(N, start, end);

        if (path != null)
        {
           
            foreach (var step in path)
            {
                Console.WriteLine($"({step[0]}, {step[1]})");
            }
        }
        else
        {
            Console.WriteLine("No path found.");
        }
    }
}