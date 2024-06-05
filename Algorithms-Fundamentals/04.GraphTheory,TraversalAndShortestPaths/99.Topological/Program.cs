int n = int.Parse(Console.ReadLine());
Dictionary<string, List<string>> graph = new();
Dictionary<string, int> dependencies = new Dictionary<string, int>();

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
    if (input.Length == 1)
    {
        graph.Add(input[0], new List<string>());
    }
    else
    {
        graph.Add(input[0], input[1].Split(", ").ToList());
    }
}

foreach (var kvp in graph)
{
    if (!dependencies.ContainsKey(kvp.Key))
    {
        dependencies.Add(kvp.Key, 0);
    }

    foreach(var child in kvp.Value)
    {
        if (!dependencies.ContainsKey(child))
        {
            dependencies.Add(child, 0);
        }
        dependencies[child]++;
    }
}
List<string> output = new List<string>();

while (dependencies.Count>0)
{
    string nodeToRemove = dependencies.FirstOrDefault(x => x.Value == 0).Key; 
    if (nodeToRemove==null)
    {
        break;
    }
    output.Add(nodeToRemove);
    dependencies.Remove(nodeToRemove);

    foreach (var child in graph[nodeToRemove])
    {
        dependencies[child]--;
    }
}

if (dependencies.Count>0)
{
    Console.WriteLine("Invalid topological sorting");
}
else
    Console.WriteLine(string.Join(" ",output));
