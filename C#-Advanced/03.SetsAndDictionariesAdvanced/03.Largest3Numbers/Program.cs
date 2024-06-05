int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

input = input.OrderByDescending(x => x).ToArray();

for (int i = 0; i < Math.Min(3, input.Length); i++)
{
    Console.Write(input[i] + " ");
}