Dictionary<string,List<string>> graph =  new Dictionary<string,List<string>>(); 
while (true)
{
    string[] input = Console.ReadLine().Split("-");
    if (input[0] == "End")
        break;
    if (!graph.ContainsKey(input[0]))
    {
        graph.Add(input[0], new List<string>());
    }
    if (!graph.ContainsKey(input[1]))
    {
        graph.Add(input[1], new List<string>());
    }
    graph[input[0]].Add(input[1]);
}

HashSet<string> visited = new HashSet<string>();
bool acyclic = true;
HashSet<string> lastVisited = new();

foreach (var node in graph.Keys)
{
    if (!acyclic)
    {
        break;
    }
    DFS(node);
}

void DFS(string node)
{
    if (lastVisited.Contains(node))
    {
        acyclic = false;
        return;
    }
    if (visited.Contains(node))
    {
        return;
    }

    visited.Add(node);
    lastVisited.Add(node);

    foreach (var child in graph[node])
    {
        DFS(child);
    }
    lastVisited.Remove(node);
}

Console.Write("Acyclic: ");
if (acyclic)
    Console.Write("Yes");
else
    Console.Write("No");