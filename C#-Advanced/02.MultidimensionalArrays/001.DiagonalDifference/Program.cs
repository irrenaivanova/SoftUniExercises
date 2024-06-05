int n = int.Parse(Console.ReadLine());
int[,] matrix = new int[n, n];
for (int i = 0; i < n; i++)
{
    int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
    for (int j = 0; j < n; j++)
    {
        matrix[i, j] = input[j];
    }
}

int oneDiag = 0;
int secDiag = 0;

for (int i = 0; i < n; i++)
{
    oneDiag += matrix[i, i];
    secDiag += matrix[i, n - 1 - i];
}
Console.WriteLine(Math.Abs(oneDiag - secDiag));