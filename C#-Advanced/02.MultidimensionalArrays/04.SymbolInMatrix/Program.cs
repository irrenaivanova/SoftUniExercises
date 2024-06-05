int n = int.Parse(Console.ReadLine());
char[,] matrix = new char[n, n];

for (int i = 0; i < n; i++)
{
    string curr = Console.ReadLine();
    for (int j = 0; j < n; j++)
    {
        matrix[i, j] = curr[j];
    }
}

char getValue = char.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (matrix[i, j] == getValue)
        {
            Console.WriteLine($"({i}, {j})");
            return;
        }
    }
}
Console.WriteLine($"{getValue} does not occur in the matrix");