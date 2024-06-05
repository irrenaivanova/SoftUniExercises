using System.ComponentModel;

int n = int.Parse(Console.ReadLine());
List<int>[] graph = new List<int>[n];

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    if (input == "")
    {
        graph[i] = new List<int>();
    }

    else
        graph[i] = input.Split().Select(int.Parse).ToList();
}

HashSet<int> visited = new HashSet<int>();

string component = string.Empty;

for (int i = 0; i < graph.Length; i++)
{
    if (!visited.Contains(i))
    {
        List<int> components = new List<int>();
        BFS(i,components);
        Console.WriteLine($"Connected components: {string.Join(" ",components)}");
    }
}

void BFS(int i,List<int> components)
{
   Queue<int> queue = new Queue<int>();
   queue.Enqueue(i);
   visited.Add(i);
   
    while(queue.Count > 0 )
    {
        int node = queue.Dequeue();
        components.Add(node);
        foreach (var child in graph[node])
        {
            if (!visited.Contains(child))
            {
                visited.Add(child);
                queue.Enqueue(child);
            }
        }
    }
}