int n = int.Parse(Console.ReadLine());
long[][] pascal = new long[n][];

pascal[0] = new long[1] { 1 };

for (int i = 1; i < n; i++)
{
    pascal[i] = new long[i + 1];
    pascal[i][0] = 1;
    pascal[i][i] = 1;

    for (int j = 1; j < i; j++)
    {
        pascal[i][j] = pascal[i - 1][j] + pascal[i - 1][j - 1];
    }
}
foreach (var row in pascal)
{
    Console.WriteLine(string.Join(" ", row));
}