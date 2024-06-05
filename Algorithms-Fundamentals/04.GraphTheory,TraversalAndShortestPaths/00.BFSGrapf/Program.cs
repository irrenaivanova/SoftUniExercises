using System.Xml.Linq;

Dictionary<int, List<int>> graph = new()
{
    {1,new List<int>{19,21,14} },
    {19,new List<int>{7,12,31,21} },
    {7,new List<int>{1} },
    {31,new List<int>{21} },
    {21,new List<int>{14} },
    {14,new List<int>{6,23} },
    {23,new List<int>{21} },
    {12,new List<int>{} },
    {6,new List<int>{} }
};
HashSet<int> visited = new();


foreach (var node in graph.Keys)
{
    BFS(node);
}

void BFS(int startNode)
{
    if (visited.Contains(startNode))
    {
        return;
    }
    Queue<int> queue = new();
    queue.Enqueue(startNode);
    visited.Add(startNode);

    while (queue.Count > 0)
    {
        int node = queue.Dequeue();
        Console.WriteLine(node);
        foreach (var child in graph[node])
        {
            if(!visited.Contains(child))
            {
                visited.Add(child);
                queue.Enqueue(child);   
            }
        }
    }
}








