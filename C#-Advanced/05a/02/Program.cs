List<string> input = Console.ReadLine().Split().ToList();
Action<List<string>> action = x =>
{
    foreach (var item in x)
    {
        Console.WriteLine($"Sir {item}");
    }
};
action(input);