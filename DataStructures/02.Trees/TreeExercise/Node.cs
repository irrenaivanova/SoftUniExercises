namespace TreeExercise
{
    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            Value = value;
            Parent = null;
            Children = new List<TreeNode<T>>();
        }

        public T Value { get; set; }

        public TreeNode<T>? Parent { get; set; }

        public List<TreeNode<T>> Children { get; set; }
    }
}
