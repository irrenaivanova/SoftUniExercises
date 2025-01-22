using _02.Trees;
using System;
using System.Collections.Generic;


TreeNode root = new TreeNode(17);
root.Children.Add(new TreeNode(9));
root.Children.Add(new TreeNode(19));
root.Children[0].Children.Add(new TreeNode(6));
root.Children[0].Children.Add(new TreeNode(12));
root.Children[1].Children.Add(new TreeNode(25));

var root2 = new Node<int>(17);
root2.Children.Add(new Node<int>(9, new Node<int>(6), new Node<int>(12)));
root2.Children.Add(new Node<int>(19, new Node<int>(25)));

var tree = new Tree<int>();
tree.Root = root2;

BFS(root);
List<int> treeAsListBFS = tree.BFS();
Console.WriteLine(string.Join(" ", treeAsListBFS));

DFSWithPreOrder(root, 0);
List<string> treeAsDFSPreOrder = tree.DFSPreOrder(root2);
Console.WriteLine(string.Join('\n', treeAsDFSPreOrder));

DFSPostOrder(root);

DFSStack(root);

tree.AddChild(19, new Node<int>(20));
Console.WriteLine(string.Join('\n', tree.DFSPreOrder(root2)));


static void DFSStack(TreeNode root)
{
    Stack<TreeNode> stack = new Stack<TreeNode>();
    stack.Push(root);
    while (stack.Count > 0)
    {
        var current = stack.Pop();
        Console.WriteLine(current);
        foreach (var child in current.Children)
        {
            stack.Push(child);
        }
    }
}
static void BFS(TreeNode root)
{
    Queue<TreeNode> queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    while(queue.Count > 0)
    {
        var current = queue.Dequeue();
        Console.WriteLine(current);
        foreach (var child in current.Children)
        {
            queue.Enqueue(child);
        }
    }
}

static void DFSPostOrder(TreeNode node)
{
    foreach (var child in node.Children)
    {
        DFSPostOrder(child);
    }
    Console.WriteLine(node);
}

static void DFSWithPreOrder(TreeNode root, int level)
{
    Console.WriteLine(new string(' ',level) +  root);
    foreach (var child in root.Children)
    {
        DFSWithPreOrder(child, level+3);
    }
}

static void DFSWithStack(TreeNode root)
{
    if (root == null) return;

    Stack<TreeNode> stack = new Stack<TreeNode>();
    Stack<TreeNode> output = new Stack<TreeNode>(); 

    stack.Push(root);

    while (stack.Count > 0)
    {
        TreeNode current = stack.Pop();
        output.Push(current); 

        foreach (var child in current.Children)
        {
            stack.Push(child);
        }
    }
    while (output.Count > 0)
    {
        Console.WriteLine(output.Pop().Value);
    }
}

class TreeNode
{
    public int Value;
    public List<TreeNode> Children;

    public TreeNode(int value)
    {
        Value = value;
        Children = new List<TreeNode>();
    }
    public override string ToString()
    {
        return this.Value.ToString();
    }
}