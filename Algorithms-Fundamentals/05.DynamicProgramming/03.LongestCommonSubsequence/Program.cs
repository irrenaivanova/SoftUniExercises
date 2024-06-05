string first = Console.ReadLine();
string second = Console.ReadLine();

int[,] matrix = new int[first.Length + 1, second.Length + 1];

for (int i = 0; i < matrix.GetLength(1); i++)
{
    matrix[0, i] = 0;
}
for (int i = 0; i < matrix.GetLength(0); i++)
{
    matrix[i, 0] = 0;
}

for (int i = 1; i < matrix.GetLength(0); i++)
{
    for (int j = 1; j < matrix.GetLength(1); j++)
    {
        if (first[i-1] == second[j-1])
        {
            matrix[i,j] = matrix[i-1,j-1]+1;
            continue;
        }
        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
    }
}
int match = matrix[first.Length, second.Length];
Console.WriteLine(match);

Console.WriteLine(FindThePath(matrix));

string FindThePath(int[,] matrix)
{
    string path = string.Empty;
    int[] start = new int[] { first.Length, second.Length };
    while (true)
    {
        if (path.Length==match)
        {
            break;
        }

        int[] left = new int[] { start[0], start[1] - 1 };
        int[] upper = new int[] { start[0] - 1, start[1] };
        int[] diag = new int[] { start[0] - 1, start[1]-1 };

        if (matrix[left[0], left[1]] == matrix[start[0], start[1]])
        {
            start[0] = left[0];
            start[1] = left[1];
            continue;
        }
        if (matrix[upper[0], upper[1]] == matrix[start[0], start[1]])
        {
            start[0] = upper[0];
            start[1] = upper[1];
            continue;
        }
        path += first[start[0] - 1];
        start[0] = diag[0];
        start[1] = diag[1];
    }
    char[] arr = path.ToCharArray();
    Array.Reverse(arr);
    return new String(arr);

}