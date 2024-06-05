int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
Queue<int> queue = new Queue<int>(numbers.Take(commands[0]));
int lookUpNumber = commands[2];

for (int i = 0; i < commands[1]; i++)
{
    if (queue.Count > 0)
    {
        queue.Dequeue();
    }
}
if (queue.Count == 0)
{
    Console.WriteLine("0");
}
else if (queue.Contains(lookUpNumber))
{
    Console.WriteLine("true");
}
else
{
    Console.WriteLine(queue.Min());
}