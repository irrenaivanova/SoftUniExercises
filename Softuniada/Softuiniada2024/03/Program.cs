int[] numbers = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x=>x).ToArray();
int count = int.Parse(Console.ReadLine());
Stack<int> result = new Stack<int>();
for (int i = 0; i < count; i++)
{
    result.Push(numbers[i]);
}
Console.WriteLine(string.Join("\n",result));