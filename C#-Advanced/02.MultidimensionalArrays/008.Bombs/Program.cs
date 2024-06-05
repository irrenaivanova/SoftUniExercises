int n = int.Parse(Console.ReadLine());
int[,] matrix = new int[n, n];
List<int[]> bombs = new List<int[]>();

for (int i = 0; i < n; i++)
{
    int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
    for (int j = 0; j < n; j++)
    {
        matrix[i, j] = input[j];
    }
}

string[] inputLine = Console.ReadLine().Split();
for (int i = 0; i < inputLine.Length; i++)
{
    int[] coordBombs = inputLine[i].Split(",").Select(int.Parse).ToArray();
    bombs.Add(coordBombs);
}

foreach (int[] bomb in bombs)
{
    int x = bomb[0];
    int y = bomb[1];
    int bombValue = matrix[x, y];

    if (bombValue <= 0)
        continue;

    int startXBomb = x - 1;
    int startYBomb = y - 1;
    int endXBomb = x + 1;
    int endYBomb = y + 1;

    if (startXBomb < 0)
        startXBomb = 0;
    if (startYBomb < 0)
        startYBomb = 0;
    if (endXBomb > n - 1)
        endXBomb = n - 1;
    if (endYBomb > n - 1)
        endYBomb = n - 1;

    for (int i = startXBomb; i <= endXBomb; i++)
    {
        for (int j = startYBomb; j <= endYBomb; j++)
        {
            if (matrix[i, j] > 0)
            {
                matrix[i, j] -= bombValue;
            }
        }
    }
}

int activeSell = 0;
int sum = 0;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (matrix[i, j] > 0)
        {
            activeSell++;
            sum += matrix[i, j];
        }
    }
}
Console.WriteLine($"Alive cells: {activeSell}");
Console.WriteLine($"Sum: {sum}");
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}
