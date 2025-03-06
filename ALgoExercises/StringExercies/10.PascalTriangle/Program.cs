int n = int.Parse(Console.ReadLine()!);

int[][] matrix = new int[n+1][];

for (int i = 1; i <= n; i++)
{
    matrix[i] = new int[i+1];
    matrix[i][0] = 1;
    matrix[i][i] = 1; 
    
    for (int j = 1; j < i; j++)
    {
        matrix[i][j] = matrix[i - 1][j-1] + matrix[i - 1][j];
    }
}

Console.WriteLine(string.Join(" ", matrix[n]));
