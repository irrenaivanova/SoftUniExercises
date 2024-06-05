int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());

int[,] matrix = new int[n, m];

for (int i = 0; i < n; i++)
{
    int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();

    for (int j = 0; j < m; j++)
    {
        matrix[i, j] = row[j];
    }
}

int[,] newMatrix =  new int[n, m];
newMatrix[0, 0] = matrix[0, 0];

for (int i = 1; i < m; i++)
{
    newMatrix[0, i] = newMatrix[0, i - 1] + matrix[0, i];
}

for (int i = 1; i < n; i++)
{
    newMatrix[i,0] = newMatrix[i - 1,0] + matrix[i, 0];
}

for (int i = 1; i < n; i++)
{
    for (int j = 1; j < m; j++)
    {
        newMatrix[i,j] = matrix[i,j] + Math.Max(newMatrix[i,j-1], newMatrix[i-1,j]);
    }
}

Stack<int[]> path = FindThePath(newMatrix);
Console.WriteLine(string.Join(" ", path.Select(x => $"[{x[0]}, {x[1]}]")));

Stack<int[]> FindThePath(int[,] newMatrix)
{
    Stack<int[]> result = new Stack<int[]>();

    int[] start = new[] { n-1, m-1 };
    result.Push(start);

    while (true)
    {
        if (start[0] == 0 && start[1] == 0)
        {
            break;
        }

        int[] upper = new int[] { start[0] - 1, start[1] };
        int[] left = new int[] { start[0], start[1] - 1 };

        if (!IsValid(upper))        
        {
            result.Push(left);
            start = left;
            continue;
        }
        if (!IsValid(left))
        {
            result.Push(upper);
            start = upper;
            continue;
        }
        if (newMatrix[left[0], left[1]] >= newMatrix[upper[0], upper[1]])
        {
            result.Push(left);
            start = left;
        }
        if(newMatrix[left[0], left[1]] < newMatrix[upper[0], upper[1]])
        {
            result.Push(upper);
            start = upper;
        }
    }
    return result;
}

bool  IsValid(int[] pos)
{
    if (pos[0] < 0 || pos[1] < 0)
    {
        return false;
    }
    return true;
}

void PrintTheMatrix(int[,] matrix)
{
    Console.WriteLine(new string('-',20));
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            Console.Write(matrix[i,j]+" ");
        }
        Console.WriteLine();
    }
}