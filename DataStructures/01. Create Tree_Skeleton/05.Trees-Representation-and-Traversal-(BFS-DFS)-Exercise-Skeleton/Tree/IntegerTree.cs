namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public List<List<int>> GetPathsWithGivenSum(int sumPath)
        {
            List<Tree<int>> leaves = new List<Tree<int>>();
            Queue<Tree<int>> queue = new Queue<Tree<int>>();
            queue.Enqueue(this);
            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Children.Count == 0)
                {
                    leaves.Add(current);
                }
                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
            List<List<int>> leavesWithSum = new List<List<int>>();
            foreach (var leaf in leaves)
            {
                int sum = 0;
                List<int> path = new List<int>();

                var node = leaf;
                while (node != null)
                {
                    sum += node.Key;
                    path.Add(node.Key);
                    node = node.Parent;
                }
                if (sum == sumPath)
                {
                    path.Reverse();
                    leavesWithSum.Add(path);
                }
            }
            return leavesWithSum;
        }
        public List<List<int>> GetPathsWithGivenSumDFS(int sumPath)
        {
            var allPaths = new List<List<int>>();
            var currentPath = new List<int>();
            FindAllPaths(this, currentPath, allPaths);
            return allPaths;
        }

        private void FindAllPaths(IntegerTree node, List<int> currentPath, List<List<int>> allPaths)
        {
            if (node == null)
            {
                return;
            }  
            currentPath.Add(node.Key);
            if (node.Children.Count == 0)
            {
                allPaths.Add(new List<int>(currentPath));  
            }
            else
            {
                foreach (var child in node.Children)
                {
                    FindAllPaths((IntegerTree)child, currentPath, allPaths);
                }
            }

            currentPath.RemoveAt(currentPath.Count - 1);
        }

        public List<List<int>> GetSubtreesWithGivenSum(int sum)
        {
            List<IntegerTree> allNodes = new List<IntegerTree>();
            FindAllNodes(this, allNodes);
            GiveallChildren();
        }
    }
}
