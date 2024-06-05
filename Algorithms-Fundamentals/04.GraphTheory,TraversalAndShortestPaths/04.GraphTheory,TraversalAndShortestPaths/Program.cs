using System.ComponentModel;

int n = int.Parse(Console.ReadLine());
List<int>[] graph = new List<int>[n];

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
    {
        graph[i] = new List<int>();
    }
    
    else
        graph[i] = input.Split().Select(int.Parse).ToList();
}

HashSet<int> visited = new HashSet<int>();
List<string> components = new List<string>();
string component = string.Empty;

for (int i = 0; i < graph.Length; i++)
{
    if (!visited.Contains(i))
    {
        DFS(i);
        components.Add(component);
        component = string.Empty;
    }
}

Console.WriteLine(string.Join("\n",components.Select(x=>$"Connected components: {x}")));
void DFS(int i)
{
    if (visited.Contains(i))
    {
        return;
    }
    visited.Add(i);
    foreach (var child in graph[i])
    {
        DFS(child);
    }
    component += i + " "; 
}