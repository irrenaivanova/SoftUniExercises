int[] dim = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
int row = dim[0];
int col = dim[1];
int[,] matrix = new int[row, col];
for (int i = 0; i < row; i++)
{
    int[] curr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
    for (int j = 0; j < col; j++)
    {
        matrix[i, j] = curr[j];
    }
}
int maxSum = int.MinValue;
int maxrow = -1;
int maxcol = -1;

for (int i = 0; i < row - 1; i++)
{
    for (int j = 0; j < col - 1; j++)
    {
        int sum = 0;
        sum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
        if (sum > maxSum)
        {
            maxSum = sum;
            maxrow = i;
            maxcol = j;
        }
    }
}
Console.WriteLine(matrix[maxrow, maxcol] + " " + matrix[maxrow, maxcol + 1]);
Console.WriteLine(matrix[maxrow + 1, maxcol] + " " + matrix[maxrow + 1, maxcol + 1]);
Console.WriteLine(maxSum);
