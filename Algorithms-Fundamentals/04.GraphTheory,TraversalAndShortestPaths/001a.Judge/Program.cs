using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel;
using System.Security.Cryptography;

namespace Algorithms
{
    public class Program
    {
        private static Dictionary<int, List<int>> graph;
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            graph = new();
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                graph[input[0]] = new List<int>();
                if (input.Length > 1)
                {
                    graph[input[0]].AddRange(input[1..]);
                }
            }

            Dictionary<int[], int> result = new();

            for (int i = 0; i < m; i++)
            {
                int[] points = Console.ReadLine().Split("-").Select(int.Parse).ToArray();
                int shortDistance = FindTheShortestDIstance(points[0], points[1]);
                result.Add(new int[] { points[0], points[1] }, shortDistance);
            }

            Console.WriteLine(string.Join("\n", result.Select(x => $"{{{x.Key[0]}, {x.Key[1]}}} -> {x.Value}")));

        }
        private static int FindTheShortestDIstance(int start, int end)
        {
            int shortest = -1;
            Dictionary<int, int> parent = new();
            foreach (var node in graph.Keys)
            {
                if (!parent.ContainsKey(node))
                {
                    parent.Add(node, -1);
                }
            }

            List<int> visited = new();
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                int nodeToRemove = queue.Dequeue();
                if (nodeToRemove == end)
                {
                    shortest = GetThePath(parent, end);
                    break;
                }
                foreach (var child in graph[nodeToRemove])
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                        parent[child] = nodeToRemove;
                    }
                }
            }
            return shortest;
        }

        private static int GetThePath(Dictionary<int, int> parent, int end)
        {
            int count = -1;
            while (true)
            {
                int node = end;
                end = parent[end];
                count++;
                if (parent[end] == -1)
                {
                    break;
                }
            }
            if (count > -1)
            {
                return count + 1;
            }
            return count;
        }
    }
}