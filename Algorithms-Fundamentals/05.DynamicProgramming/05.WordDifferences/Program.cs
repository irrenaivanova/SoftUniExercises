string first = Console.ReadLine();
string second = Console.ReadLine();

int[,] matrix = new int[first.Length+1, second.Length+1];

for (int i = 0; i < matrix.GetLength(1); i++)
{
    matrix[0, i] = i;
}

for (int i = 0; i < matrix.GetLength(0); i++)
{
    matrix[i, 0] = i;
}

for (int i = 1; i < matrix.GetLength(0); i++)
{
    for (int j = 1; j < matrix.GetLength(1); j++)
    {
        if (first[j-1] == second[i - 1])
        {
            matrix[i,j] = matrix[i-1,j-1];
        }
        else
        {
            matrix[i,j] = Math.Min(matrix[i,j-1], matrix[i-1,j])+1;
        }
    }
}
Console.WriteLine(matrix[first.Length,second.Length]);