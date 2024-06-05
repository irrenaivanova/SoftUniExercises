int n = int.Parse(Console.ReadLine());

int[][] pascal = new int[n+1][];

pascal[0] = new int[1];
pascal[0][0] = 1;
for (int i = 1; i < n+1; i++)
{
    pascal[i] = new int[i+1];
    pascal[i][0] = 1;
    pascal[i][i] = 1;
    if (i > 1)
    {
        for (int j = 1; j < i; j++)
        {
            pascal[i][j] = pascal[i - 1][j] + pascal[i - 1][j - 1];
        }
    }
}
Console.WriteLine(string.Join(" ", pascal[n]));