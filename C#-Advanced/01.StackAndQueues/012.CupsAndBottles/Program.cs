Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
int wastedWatter = 0;
int waterExtra = 0;
while (cups.Count > 0 && bottles.Count > 0)
{
    if (bottles.Peek() + waterExtra >= cups.Peek())
    {
        wastedWatter += bottles.Pop() + waterExtra - cups.Dequeue();
        waterExtra = 0;
    }
    else
    {
        waterExtra += bottles.Pop();
    }
}

if (cups.Count > 0)
{
    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
}
if (bottles.Count > 0)
{
    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
}
Console.WriteLine($"Wasted litters of water: {wastedWatter}");