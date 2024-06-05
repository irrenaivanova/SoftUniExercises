string[] input = Console.ReadLine().Split();

Dictionary<char, int> output = new Dictionary<char, int>();

for (int i = 0; i < input.Length; i++)
{
    for (int j = 0; j < input[i].Length; j++)
    {
        if (!output.ContainsKey(input[i][j]))
        {
            output.Add(input[i][j], 0);
        }

        output[input[i][j]]++;
    }
}
foreach (var item in output)
{
    Console.WriteLine($"{item.Key} -> {item.Value}");
}
