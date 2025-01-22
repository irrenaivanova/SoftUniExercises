namespace _02.Trees
{
    public class Node<T>
    {
        public T Value { get; set; }
        public List<Node<T>> Children { get; set; }
        public Node(T value)
        {
            this.Value = value;
            this.Children = new List<Node<T>>();
        }
        public Node(T value, params Node<T>[] children)
        {
            this.Value = value;
            this.Children = children.ToList();
        }
    }
}
