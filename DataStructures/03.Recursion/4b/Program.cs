int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());
List<int[]> results = new List<int[]>();



for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        results.Add(new int[] { i, j });
    }
}

Console.WriteLine(string.Join("\n", results.Select(x => string.Join(" ", x))));