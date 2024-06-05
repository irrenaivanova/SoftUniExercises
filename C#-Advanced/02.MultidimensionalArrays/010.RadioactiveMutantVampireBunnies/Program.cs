int[] dim = Console.ReadLine().Split().Select(int.Parse).ToArray();
char[,] matrix = new char[dim[0], dim[1]];
for (int i = 0; i < dim[0]; i++)
{
    string input = Console.ReadLine();
    for (int j = 0; j < dim[1]; j++)
    {
        matrix[i, j] = input[j];
    }
}

string moves = Console.ReadLine();
int x = -1;
int y = -1;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] == 'P')
        {
            x = i;
            y = j;
        }
    }
}
bool isWin = false;
bool isDead = false;
foreach (char move in moves)
{
    matrix[x, y] = '.';
    if (move == 'U' && IsInTheRange(matrix, x - 1, y))
        x--;
    else if (move == 'D' && IsInTheRange(matrix, x + 1, y))
        x++;
    else if (move == 'L' && IsInTheRange(matrix, x, y - 1))
        y--;
    else if (move == 'R' && IsInTheRange(matrix, x, y + 1))
        y++;
    else
    {
        isWin = true;
    }

    if (matrix[x, y] == 'B' && !isWin)
    {
        isDead = true;
    }
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] == 'B')
            {
                int startX = i - 1;
                int endX = i + 1;
                int startY = j - 1;
                int endY = j + 1;

                if (startX < 0)
                    startX = 0;
                if (endX > matrix.GetLength(0) - 1)
                    endX = matrix.GetLength(0) - 1;
                if (startY < 0)
                    startY = 0;
                if (endY > matrix.GetLength(1) - 1)
                    endY = matrix.GetLength(1) - 1;

                if (matrix[i, startY] != 'B')
                    matrix[i, startY] = 'C';

                if (matrix[i, endY] != 'B')
                    matrix[i, endY] = 'C';

                if (matrix[startX, j] != 'B')
                    matrix[startX, j] = 'C';

                if (matrix[endX, j] != 'B')
                    matrix[endX, j] = 'C';
            }
        }
    }

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] == 'C')
            {
                matrix[i, j] = 'B';
            }
        }
    }
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[x, y] == 'B' && !isWin)
            {
                isDead = true;
            }
        }
    }
    if (isDead || isWin)
        break;
}

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write(matrix[i, j]);
    }
    Console.WriteLine();
}

if (isWin)
    Console.WriteLine($"won: {x} {y}");
if (isDead)
    Console.WriteLine($"dead: {x} {y}");
bool IsInTheRange(char[,] matrix, int x, int y)
{
    return (x >= 0 && x < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1));
}
