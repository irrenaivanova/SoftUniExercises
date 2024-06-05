
int n = int.Parse(Console.ReadLine());
Dictionary<string, List<string>> graph = new();

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

HashSet<string> visited = new HashSet<string>();
Stack<string> stack = new Stack<string>();
HashSet<string> cycle = new HashSet<string>();

foreach (var node in graph.Keys)
{
    try
    {
        DFS(node);
    }
    catch (Exception e) 
    {
        Console.WriteLine(e.Message);
        return;
    }
    
}

void DFS(string node)
{
    if (cycle.Contains(node))
    {
        throw new InvalidOperationException("cycle graph");
    }


    if (visited.Contains(node))
    {
        return; 
    }

    visited.Add(node);
    cycle.Add(node);

    foreach (var child in graph[node])
    {
        DFS(child);
    }
    stack.Push(node);
    cycle.Remove(node);
}
Console.WriteLine(string.Join(" ",stack));