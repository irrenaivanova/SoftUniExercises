int n = int.Parse(Console.ReadLine());
int[][] triangle = new int[n][];
for (int i = 0; i < n; i++)
{
    triangle[i] = new int[i + 1];
    triangle[i][0] = 1;
    triangle[i][i] = 1;

    if (i >= 2)
        for (int j = 1; j < i; j++)
        {
            triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
        }
}


for (int i = 0; i < n; i++)
{
    for (int j = 0; j <= i; j++)
    {
        Console.Write(triangle[i][j] + " ");
    }
    Console.WriteLine();
}
