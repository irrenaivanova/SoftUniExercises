using System.Collections.Generic;
using System.Linq;

int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());

List<int>[] graph = new List<int>[n];
Dictionary<int, int> dependancies = new Dictionary<int, int>();

for (int i = 0; i < n; i++)
{
    graph[i] = new List<int>();
}
for (int i = 0; i < m; i++)
{
    int[] edges = Console.ReadLine().Split().Select(int.Parse).ToArray();
    graph[edges[0]].Add(edges[1]);
}

for (int i = 0; i < graph.Length; i++)
{
    if (!dependancies.ContainsKey(i))
    {
        dependancies.Add(i, 0);
    }
    foreach (var child in graph[i])
    {
        if (!dependancies.ContainsKey(child))
        {
            dependancies.Add(child, 0);
        }
        dependancies[child]++;
    }
}

List<int> result = new List<int>();

while (true)
{
    int nodeToRemoveFirst = -1;
    if (dependancies.Count == 0)
    {
        break;
    }
    try
    {
        nodeToRemoveFirst = dependancies.First(x => x.Value == 0).Key;
    }
    catch (Exception)
    {
        break;
    }

    Dictionary<int, int> nodesToRemove = dependancies.Where(x => x.Value == 0).ToDictionary(x=>x.Key,x=>x.Value);

    if (nodesToRemove.Count>1)
    {
        nodesToRemove = nodesToRemove.OrderBy(x=>x.Key).ToDictionary(x => x.Key, x => x.Value);
    }
    int nodeToRemove= nodesToRemove.First(x=>x.Value==0).Key;

    foreach (var child in graph[nodeToRemove])
    {
        dependancies[child]--;
    }
    result.Add(nodeToRemove);
    dependancies.Remove(nodeToRemove);
}

if (dependancies.Count == 0)
{
    Console.WriteLine(string.Join(" ", result));
}
else
    Console.WriteLine("circular dependency");

