int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());

HashSet<int>[] graph = new HashSet<int>[n+1];
int[] parent = new int[n+1];
Array.Fill(parent, -1);

for (int j = 0; j < graph.Length; j++)
{
    graph[j] = new HashSet<int>();
}

for (int i = 0; i < m; i++)
{
    int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
    graph[input[0]].Add(input[1]);
    graph[input[1]].Add(input[0]);
}

int start = int.Parse(Console.ReadLine());
int end = int.Parse(Console.ReadLine());
Stack<int> path = new();
HashSet<int> visited = new(); 
BFS(start);

void BFS(int start)
{
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(start);
    visited.Add(start); 

    while(queue.Count > 0)
    {
        int nodeToRemove = queue.Dequeue();
        Console.WriteLine(nodeToRemove);
        
        if (nodeToRemove == end)
        {
            path.Push(end);
            GetPath(end);
            Console.WriteLine($"Shortest path length is: {path.Count-1}");
            Console.WriteLine(string.Join(" ", path));
            break;
        }
        foreach (var child in graph[nodeToRemove])
        {
            if (!visited.Contains(child))
            {
                queue.Enqueue(child);
                visited.Add(child);
                parent[child] = nodeToRemove;
            } 
        }
    }
}

void GetPath(int end)
{
    if (parent[end] == -1)
    {
        return;
    }
    path.Push(parent[end]);
    GetPath(parent[end]);
}