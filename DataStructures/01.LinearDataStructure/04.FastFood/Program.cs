int food = int.Parse(Console.ReadLine()!);
Queue<int> orders = new Queue<int>(Console.ReadLine()!.Split().Select(int.Parse));

Console.WriteLine(orders.Max());

while(orders.Count > 0)
{
    if (orders.Peek()>food)
    {
        Console.WriteLine($"Orders left: {string.Join(" ",orders)}");
        return;
    }
    food -= orders.Dequeue();
}
Console.WriteLine("Orders complete");