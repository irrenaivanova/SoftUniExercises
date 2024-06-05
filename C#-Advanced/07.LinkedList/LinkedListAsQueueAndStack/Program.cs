LinkedList<int> stack = new LinkedList<int>();

stack.AddFirst(0);
stack.AddFirst(1);
stack.AddFirst(2);
stack.AddFirst(3);
stack.AddFirst(4);
stack.AddFirst(5);
    
while (stack.Count > 0)
{
    int value = stack.First.Value;
    stack.RemoveFirst();
    Console.WriteLine(value);
}



