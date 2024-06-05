using System.ComponentModel;
using System.IO;
using System.Xml.Linq;

int n = int.Parse(Console.ReadLine());
SortedDictionary<string,List<string>> graph = new SortedDictionary<string,List<string>>();

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(" -> ");
    if (!graph.ContainsKey(input[0]))
    {
        graph[input[0]] = new List<string>();
    }
    graph[input[0]].AddRange(input[1].Split());
}
foreach (var node in graph)
{
    node.Value.Sort();  
}

List<string[]> output= new List<string[]>();
bool isPath = false;
List<string> visited = new List<string>();

foreach (var node in graph)
{
    for (int i = 0; i < node.Value.Count; i++)
    {
        string edgeFrom = node.Key;
        string edgeTo = node.Value[i];
        
        graph[edgeFrom].Remove(edgeTo);
        graph[edgeTo].Remove(edgeFrom);

        DFS(edgeFrom, edgeTo);
        visited.Clear();

        if (isPath)
        {
            i--;
            output.Add(new string[2] { edgeFrom, edgeTo });
        }
        else
        {
            graph[edgeFrom].Remove(edgeTo);
            graph[edgeTo].Remove(edgeFrom);
        }
        isPath = false;
    }
 }

Console.WriteLine($"Edges to remove: {output.Count}");
Console.WriteLine(string.Join("\n", output.Select(x => $"{x[0]} - {x[1]}")));

void DFS(string edgeTo, string edgeFrom)
{
    if (visited.Contains(edgeTo))
    {
        return;
    }
    visited.Add(edgeTo);
    
    if (edgeTo==edgeFrom)
    {
        isPath = true;
        return;
    }
    
    foreach (var child in graph[edgeTo])
    {
        DFS(child, edgeFrom);
    }
}
