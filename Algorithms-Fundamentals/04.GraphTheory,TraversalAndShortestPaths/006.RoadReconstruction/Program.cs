//може проверката накрая да бъде направена с един булев масив
//вместо лист визитед , и вместо с каунт,  да видим дали
//всички неща от матрицата са посетени

int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());

List<int>[] graph = new List<int>[n];
List<Edge> edges = new List<Edge>();

for (int i = 0; i < m; i++)
{
    int[] input = Console.ReadLine().Split(" - ").Select(int.Parse).ToArray();
    if (graph[input[0]] == null)
    {
        graph[input[0]] = new List<int>();
    }
    if (graph[input[1]] == null) 
    {
        graph[input[1]] = new List<int>();
    }
    graph[input[0]].Add(input[1]);
    graph[input[1]].Add(input[0]);
    edges.Add(new Edge() { First = input[0], Second = input[1] });
}

HashSet<int[]> streets = new HashSet<int[]>();

List<int> visited =new List<int>();
int count = 0;

foreach (var edge in edges)
{
    graph[edge.First].Remove(edge.Second);
    graph[edge.Second].Remove(edge.First);

    DFS(0);
    if (count < graph.Length)
    {
        streets.Add(new int[2] { edge.First, edge.Second });
    }

    visited.Clear();
    count = 0;
    graph[edge.First].Add(edge.Second);
    graph[edge.Second].Add(edge.First);
}
    
Console.WriteLine("Important streets");
Console.WriteLine(string.Join("\n", streets.Select(x => $"{x[0]} {x[1]}")));

void DFS(int k)
{
    if (visited.Contains(k))
    {
        return;
    }
    visited.Add(k);

    foreach (var child in graph[k])
    {
        DFS(child);
    }

    count++;
}

class Edge
{
    public int First { get; set; }
    public int Second { get; set; }
}