namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public IntegerTreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == null)
                {
                    continue;
                }
                int[] parentchild  = input[i].Split(' ').Select(int.Parse).ToArray();
                int parent = parentchild[0];
                int child = parentchild[1];

                this.CreateNodeByKey(parent);
                this.CreateNodeByKey(child);
                this.AddEdge(parent, child);
            }
            return GetRoot();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            if (!nodesByKey.ContainsKey(key))
            {
                this.nodesByKey.Add(key, new IntegerTree(key));
            }
            return this.nodesByKey[key];
        }

        public void AddEdge(int parent, int child)
        {
            IntegerTree treeParent = nodesByKey[parent];
            IntegerTree treeChild = nodesByKey[child];
            treeParent.AddChild(treeChild);
            treeChild.AddParent(treeParent);
        }

        public IntegerTree GetRoot()
        {
            var node = this.nodesByKey.FirstOrDefault().Value;
            while (node.Parent != null)
            {
                node = (IntegerTree)node.Parent;
            }
            return node;
        }
    }
}
