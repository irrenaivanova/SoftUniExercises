int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

for (int i = 0; i < numbers[1]; i++)
{
    if (queue.Count() != 0)
    {
        queue.Dequeue();
    }
}
if (queue.Count() == 0)
{
    Console.WriteLine("0");
    return;
}
int min = int.MaxValue;
while (queue.Count() != 0)
{
    int number = queue.Dequeue();
    if (number == numbers[2])
    {
        Console.WriteLine("true");
        return;
    }
    if (number < min)
    {
        min = number;
    }
}
Console.WriteLine(min);