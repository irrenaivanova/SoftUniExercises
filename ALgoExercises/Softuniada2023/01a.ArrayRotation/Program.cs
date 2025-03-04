Queue<int> input = new Queue<int>(Console.ReadLine()!.Split().Select(int.Parse).ToArray());
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    int current = input.Dequeue();
    input.Enqueue(current);
}

Console.WriteLine(string.Join(" ",input));
