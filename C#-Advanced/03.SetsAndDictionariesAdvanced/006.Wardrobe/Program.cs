int n = int.Parse(Console.ReadLine());
Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(" -> ");
    string color = input[0];
    string[] items = input[1].Split(",");

    if (!clothes.ContainsKey(color))
    {
        clothes.Add(color, new Dictionary<string, int>());
    }
    foreach (var item in items)
    {
        if (!clothes[color].ContainsKey(item))
        {
            clothes[color].Add(item, 0);
        }
        clothes[color][item]++;
    }
}
string[] clothToFind = Console.ReadLine().Split();

foreach (var color in clothes)
{
    Console.WriteLine($"{color.Key} clothes:");
    foreach (var item in color.Value)
    {
        if (color.Key == clothToFind[0] && item.Key == clothToFind[1])
        {
            Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
        }
        else
        {
            Console.WriteLine($"* {item.Key} - {item.Value}");
        }
    }
}