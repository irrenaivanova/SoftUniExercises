int[] dim = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int row = dim[0];
int col = dim[1];

double[,] matrix = new double[row, col];

int findRow = 3;
int findCol = 3;

for (int i = 0; i < row; i++)
{
    double[] curr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
    for (int j = 0; j < col; j++)
    {
        matrix[i, j] = curr[j];
    }
}

if (row < 3 || col < 3)
    return;

double maxSum = double.MinValue;
int maxrow = -1;
int maxcol = -1;

for (int i = 0; i < row - findRow + 1; i++)
{
    for (int j = 0; j < col - findCol + 1; j++)
    {
        double sum = 0;
        for (int a = 0; a < findRow; a++)
        {
            for (int b = 0; b < findCol; b++)
            {
                sum += matrix[i + a, j + b];
            }
        }
        if (sum > maxSum)
        {
            maxSum = sum;
            maxrow = i;
            maxcol = j;
        }
    }
}

Console.WriteLine($"Sum = {maxSum}");
for (int i = maxrow; i < maxrow + findRow; i++)
{
    for (int j = maxcol; j < maxcol + findCol; j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}
