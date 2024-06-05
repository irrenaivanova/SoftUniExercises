int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
Queue<int> queue = new Queue<int>();

for (int i = 0; i < input.Length; i++)
{
    if (input[i] % 2 == 0)
    { queue.Enqueue(input[i]); }
}
Console.WriteLine(string.Join(", ", queue));