int n=int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());

Dictionary<int, List<int>> graph = new();
for (int i = 0; i < n; i++)
{ 
    int[] input = Console.ReadLine().Split(new char[] { ':', ' ' },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    graph[input[0]] = new List<int>();
    if (input.Length > 1)
    {
        graph[input[0]].AddRange(input[1..]);
    }
}

Dictionary<int[], int> result = new();

for (int i = 0; i < m; i++)
{
    int[] points = Console.ReadLine().Split("-").Select(int.Parse).ToArray();
    int shortDistance = FindTheShortestDIstance(points[0], points[1]);
    result.Add(new int[] { points[0], points[1] },shortDistance);
}

Console.WriteLine(string.Join("\n", result.Select(x => $"{{{x.Key[0]}, {x.Key[1]}}} -> {x.Value}")));

int FindTheShortestDIstance(int start, int end)
{
    Dictionary<int,int> parent = new() { { start, -1 } };
  
    List<int> visited = new();
    Queue<int> queue = new Queue<int>();

    queue.Enqueue(start);
    visited.Add(start);

    while (queue.Count > 0)
    {
        int nodeToRemove = queue.Dequeue();
        if (nodeToRemove==end)
        {
            return GetThePath(parent,end);
        }
        foreach (var child in graph[nodeToRemove])
        {
            if(!visited.Contains(child))
            {
                queue.Enqueue(child);
                visited.Add(child);
                parent[child] = nodeToRemove;
            }
        }
    }
    return -1;
}

int GetThePath(Dictionary<int,int> parent, int end)
{
    int steps = 0;
    int node = end;
    while(parent[end] != -1)
    {
        end = parent[end];
        steps++;
    }
    return steps;
}