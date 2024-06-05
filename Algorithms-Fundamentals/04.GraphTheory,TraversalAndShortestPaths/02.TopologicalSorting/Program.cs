
int n = int.Parse(Console.ReadLine());
Dictionary<string, List<string>> graph = new();
Dictionary<string,int> dependancies = new Dictionary<string,int>();

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split("->",StringSplitOptions.RemoveEmptyEntries).Select(x=>x.Trim()).ToArray();
    if (input.Length == 1)
    {
        graph.Add(input[0],new List<string>());
    }
    else
    {
        graph.Add(input[0], input[1].Split(", ").ToList());
    }   
}

foreach (var kvp in graph)
{
    if (!dependancies.ContainsKey(kvp.Key))
    {
        dependancies.Add(kvp.Key, 0);
    }

    foreach (var child in kvp.Value)
    {
        if (!dependancies.ContainsKey(child))
        {
            dependancies.Add(child, 0);
        }
        dependancies[child]++;
    }
}

List<string> result = new List<string>();

while(true)
{
    if (dependancies.Count == 0)
    {
        break;
    }

    string nodeToRemove = dependancies.FirstOrDefault(x => x.Value == 0).Key;
    
    if (nodeToRemove==null)
    {
        break;
    }
    foreach (var child in graph[nodeToRemove])
    {
        dependancies[child]--;
    }
    result.Add(nodeToRemove);
    dependancies.Remove(nodeToRemove);
}

if (dependancies.Count==0)
{
    Console.WriteLine($"Topological sorting: {string.Join(", ",result)}");
}
else
    Console.WriteLine("Invalid topological sorting");

