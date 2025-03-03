int n = int.Parse(Console.ReadLine()!);
int[] previous = new int[] { 1, 1 };
int[]row = new int[2];

for (int i = 2; i <= n; i++)
{
    row = new int[i + 1];
    row[0] = 1;
    row[i] = 1;
    
    for (int j = 1; j < i; j++)
    {
        row[j] = previous[j-1] + previous[j];

    }
    previous = row.ToArray();
}

Console.WriteLine(string.Join(" ",row));