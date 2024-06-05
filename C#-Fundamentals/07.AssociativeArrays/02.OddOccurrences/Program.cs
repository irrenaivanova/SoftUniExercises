string[] input = Console.ReadLine().Split().Select(x => x.ToLower()).ToArray();
Dictionary<string, int> result = new Dictionary<string, int>();

for (int i = 0; i < input.Length; i++)
{
    if (!result.ContainsKey(input[i]))
    {
        result.Add(input[i], 0);
    }

    result[input[i]]++;
}

foreach (var item in result)
{
    if (item.Value % 2 != 0)
        Console.Write($"{item.Key} ");
}