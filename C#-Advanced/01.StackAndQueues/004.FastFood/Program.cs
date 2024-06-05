int quantity = int.Parse(Console.ReadLine());
Queue<int> orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

Console.WriteLine(orders.Max());

while (orders.Count > 0)
{
    if (quantity >= orders.Peek())
    {
        quantity -= orders.Peek();
        orders.Dequeue();
    }
    else
    {
        Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
        return;
    }
}
Console.WriteLine("Orders complete");