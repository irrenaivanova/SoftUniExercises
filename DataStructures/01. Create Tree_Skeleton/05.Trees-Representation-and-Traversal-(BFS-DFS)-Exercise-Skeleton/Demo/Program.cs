namespace Demo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Tree;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.AppendLine(Console.ReadLine());
            }
            var treeFactory = new IntegerTreeFactory();
            var tree = treeFactory.CreateTreeFromStrings(sb.ToString().Trim().Split("\r\n"));
            Console.WriteLine(treeFactory.GetRoot().Key);

            var treeAsString = tree.AsString();
            Console.WriteLine(treeAsString);

            var treeNodes = tree.GetLeafKeys().ToList().OrderBy(x => x);
            Console.WriteLine($"Leaf nodes: {string.Join(", ",treeNodes)}");

            var internalNodes = tree.GetInternalKeys().ToList().OrderBy(x => x);
            Console.WriteLine($"Internal nodes: {string.Join(", ", internalNodes)}");

            Console.WriteLine($"Deepest Node: {tree.GetDeepestKey()}");

            
            Console.WriteLine($"Longest path {string.Join(" ",tree.GetLongestPath().Reverse())}");

            var paths = tree.GetPathsWithGivenSum(27);
            Console.WriteLine($"Paths with sum {string.Join("\n",paths.Select(x => string.Join(" ",x)))}");

            var pathsDFS = tree.GetPathsWithGivenSumDFS(27);
            Console.WriteLine($"All paths {string.Join("\n", pathsDFS.Select(x => string.Join(" ", x)))}");

            var subTrees = tree.GetPathsWithGivenSumDFS(43);
            Console.WriteLine($"All paths {string.Join("\n", subTrees.Select(x => string.Join(" ", x)))}");
        }
    }
}
