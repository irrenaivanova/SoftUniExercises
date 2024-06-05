string[] input = Console.ReadLine().Split();
for (int i = input.Length - 1; i >= 0; i--)
{
    Console.Write($"{input[i]} ");
}