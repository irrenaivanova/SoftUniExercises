namespace _02.Trees
{
    public class Tree<T>
    {
        public Node<T> Root { get; set; }

        private List<string> list = new List<string>();
        public List<T> BFS()
        {
            List<T> list = new List<T>();
            Queue<Node<T>> queue = new Queue<Node<T>>();

            queue.Enqueue(this.Root);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                list.Add(current.Value);
                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return list;
        }

        public List<string> DFSPreOrder(Node<T> root, int level=0)
        {
            list.Add(new string(' ',level) + root.Value);
            foreach(var child in root.Children)
            {
                DFSPreOrder(child, level + 3);
            }
            return list;
        }

       
        public void AddChild(T value, Node<T> child)
        {
            bool isFound = false;
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(this.Root);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Value.Equals(value))
                {
                    current.Children.Add(child);
                    isFound = true;
                    break;
                }
                foreach (var kid in current.Children)
                {
                    queue.Enqueue(kid);
                }
            }
            if (!isFound)
            {
                Console.WriteLine("No such node");
            }
        }
    }
}
