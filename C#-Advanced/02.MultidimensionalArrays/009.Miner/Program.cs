int n = int.Parse(Console.ReadLine());
string[] moves = Console.ReadLine().Split();

char[,] matrix = new char[n, n];
for (int i = 0; i < n; i++)
{
    char[] input = Console.ReadLine().Split().Select(char.Parse).ToArray();
    for (int j = 0; j < n; j++)
    {
        matrix[i, j] = input[j];
    }
}

int x = -1;
int y = -1;
int totalCountC = 0;

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (matrix[i, j] == 'c')
            totalCountC++;
        else if (matrix[i, j] == 's')
        {
            x = i;
            y = j;
        }
    }
}

int countC = 0;
foreach (string move in moves)
{
    if (move == "up" && IsInTheRange(matrix, x - 1, y))
        x--;
    else if (move == "down" && IsInTheRange(matrix, x + 1, y))
        x++;
    else if (move == "left" && IsInTheRange(matrix, x, y - 1))
        y--;
    else if (move == "right" && IsInTheRange(matrix, x, y + 1))
        y++;


    if (matrix[x, y] == 'e')
    {
        Console.WriteLine($"Game over! ({x}, {y})");
        return;
    }
    else if (matrix[x, y] == 'c')
    {
        countC++;
        matrix[x, y] = '*';
        if (countC == totalCountC)
        {
            Console.WriteLine($"You collected all coals! ({x}, {y})");
            return;
        }
    }
}

Console.WriteLine($"{totalCountC - countC} coals left. ({x}, {y})");

bool IsInTheRange(char[,] matrix, int x, int y)
{
    return (x >= 0 && x < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1));
}
