int n = int.Parse(Console.ReadLine());
List<int>[] graph = new List<int>[n];

Dictionary<int, int> salaries = new();

for (int i = 0; i < n; i++)
{
    graph[i] = new List<int>();
    string input = Console.ReadLine();
    for (int j = 0; j < graph.Length; j++)
    {
        if (input[j] == 'Y')
        {
            graph[i].Add(j);    
        }
    }
}
int salary = 0;

for (int i = 0; i < graph.Length; i++)
{
    salary += DFS(i);
}
Console.WriteLine(salary);

int DFS(int i)
{
    if (salaries.ContainsKey(i))
    {
        return salaries[i];
    }

    if (graph[i].Count == 0)
    {
        return 1;
    }
    int salary = 0;
    
    foreach (var child in graph[i])
        {
            salary += DFS(child);
        }

    salaries[i] = salary;
    return salary;
}