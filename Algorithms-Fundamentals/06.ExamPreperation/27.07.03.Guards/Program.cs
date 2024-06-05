using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Algorithms
{
    public class Program
    {
        private List<int> nodes = new List<int>();
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            List<int>[] graph = new List<int>[n+1];
          
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int> ();
            }
            for (int i = 0; i < m; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                graph[input[0]].Add(input[1]);
            }
            int node = int.Parse(Console.ReadLine());

            BFS(node);

        }

        private static void BFS(int node)
        {
            throw new NotImplementedException();
        }
    }
}