namespace Tree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;
        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string AsString()
        {
            var sb = new StringBuilder();
            return DFS(this, 0, sb);
        }

        private string DFS(Tree<T> tree, int level, StringBuilder sb)
        {
            sb.AppendLine($"{new string(' ',level)}{tree.Key}");
            foreach (var child in tree.Children)
            {
                DFS(child, level + 2, sb);
            }
            return sb.ToString().Trim();
        }

        public IEnumerable<T> GetInternalKeys()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Children.Count > 0 && current.Parent != null)
                {
                    yield return current.Key;
                }
                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        public IEnumerable<T> GetLeafKeys()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count>0)
            {
                var current = queue.Dequeue();
                if (current.Children.Count == 0)
                {
                    yield return current.Key;
                }
                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        public T GetDeepestKey()
        {
            return GetDeepestNode().Key;
        }

        private Tree<T> GetDeepestNode()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            Tree<T> current = null;
            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                for (int i = current.Children.Count - 1; i >= 0; i--)
                {
                    queue.Enqueue(current.children[i]);
                }
            }
            return current;
        }

        public IEnumerable<T> GetLongestPath()
        {
            Tree<T> longestLeaf = GetDeepestNode();
            while (longestLeaf != null)
            {
                yield return longestLeaf.Key;
                longestLeaf = longestLeaf.Parent;
            }
        }
    }
}
