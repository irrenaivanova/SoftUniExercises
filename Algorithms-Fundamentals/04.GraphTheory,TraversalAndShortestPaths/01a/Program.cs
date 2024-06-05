using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel;

namespace Algorithms
{
    public class Program
    {
        private static List<int>[] graph;
        private static HashSet<int> visited;
        private static string component;
        public static void Main() 
        {
            int n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (input == "")
                {
                    graph[i] = new List<int>();
                }

                else
                    graph[i] = input.Split().Select(int.Parse).ToList();
            }

            visited = new HashSet<int>();
            List<string> components = new List<string>();
            component = string.Empty;

            for (int i = 0; i < graph.Length; i++)
            {
                if (!visited.Contains(i))
                {
                    DFS(i);
                    components.Add(component);
                    component = string.Empty;
                }
            }

            Console.WriteLine(string.Join("\n", components.Select(x => $"Connected component: {x}")));


        }

        private static void DFS(int i)
        {
            if (visited.Contains(i))
            {
                return;
            }
            visited.Add(i);
            foreach (var child in graph[i])
            {
                DFS(child);
            }
            component += i + " ";
        }
    }
}