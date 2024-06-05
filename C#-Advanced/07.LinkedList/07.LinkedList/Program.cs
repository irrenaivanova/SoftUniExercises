LinkedList<int> list = new();


list.AddFirst(0);
list.AddFirst(1);
list.AddFirst(2);
list.AddFirst(3);
list.AddFirst(4);
list.AddFirst(5);

list.RemoveFirst();
list.RemoveLast();

LinkedListNode<int> node = list.First;

Console.WriteLine("From head to tail");
while (node != null)
{
    Console.WriteLine(node.Value);
    node = node.Next;
}

Console.WriteLine("From tail to head");

node = list.Last;
while(node != null)
{
    Console.WriteLine(node.Value);
    node = node.Previous;
}



