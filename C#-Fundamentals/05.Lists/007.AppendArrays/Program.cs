string[] input = Console.ReadLine().Split("|");
List<int> final = new List<int>();

for (int i = input.Length - 1; i >= 0; i--)
{
    int[] lastArray = input[i]
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    final.AddRange(lastArray);
}
Console.WriteLine(string.Join(" ", final));
