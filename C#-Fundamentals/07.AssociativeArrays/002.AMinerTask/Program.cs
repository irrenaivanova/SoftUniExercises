Dictionary<string, int> output = new Dictionary<string, int>();

while (true)
{
    string resource = Console.ReadLine();

    if (resource == "stop")
        break;

    int quantity = int.Parse(Console.ReadLine());

    if (!output.ContainsKey(resource))
    {
        output.Add(resource, 0);
    }
    output[resource] += quantity;
}

foreach (var item in output)
{
    Console.WriteLine($"{item.Key} -> {item.Value}");
}