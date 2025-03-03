
int n = int.Parse(Console.ReadLine()!);
int[,] matrix = new int[n,n];
for (int i = 0; i < n; i++)
{
    int[] inputRow = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
    for (int j = 0; j < inputRow.Length; j++)
    {
        matrix[i,j] = inputRow[j];
    }
}

int[,] rotatedMatrix = new int[n,n];
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        rotatedMatrix[i, j] = matrix[n - j - 1, i];
    }
}


PrintTheMatrix(rotatedMatrix);

void PrintTheMatrix(int[,] matrix)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j <n; j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}