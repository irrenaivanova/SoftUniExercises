int n = int.Parse(Console.ReadLine());
char[,] matrix = new char[n,n];
int pollinatedFlowers = 0;

for (int i = 0; i < n; i++)
{
    string inputRow = Console.ReadLine();
    for (int j = 0; j < n; j++)
    {
        matrix[i, j] = inputRow[j];
    }
}

int[] position = FindThePositioOfBee();

while (true)
{
    string command = Console.ReadLine();
    if (command == "End")
    {
        break;
    }
    matrix[position[0], position[1]] = '.';
    MoveTheBee(command);

    if (IfTheBeeIsGone())
    {
        break;
    }

    if (matrix[position[0], position[1]] == 'f')
    {
        pollinatedFlowers++;
        matrix[position[0], position[1]] = 'B';
    }

    if (matrix[position[0], position[1]] == 'O')
    {
        matrix[position[0], position[1]] = '.';
        MoveTheBee(command);
        if (matrix[position[0], position[1]] == 'f')
        {
            pollinatedFlowers++;
            matrix[position[0], position[1]] = 'B';
        }
    }
    if (matrix[position[0], position[1]] == '.')
    {
        matrix[position[0], position[1]] = 'B';
        continue;
    }
}
if (IfTheBeeIsGone())
{
    Console.WriteLine("The bee got lost!");
}
if(pollinatedFlowers>=5)
{
    Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
}
else
{
    Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-pollinatedFlowers} flowers more");
}

PrintTheMatrix();

bool IfTheBeeIsGone()
{
    if (position[0] < 0 || position[0] >= n || position[1] < 0 || position[1] >= n)
    {
        return true;
    }
    return false;
}

void MoveTheBee(string command)
{
    if (command== "up")
    {
        position[0]--;
    }
    if (command == "down")
    {
        position[0]++;
    }
    if (command == "left")
    {
        position[1]--;
    }
    if (command == "right")
    {
        position[1]++;
    }
}



void PrintTheMatrix()
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            Console.Write(matrix[i,j]);
        }
        Console.WriteLine();
    }
}
int[] FindThePositioOfBee()
{
    int[] pos = new int[2];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (matrix[i, j] == 'B')
            {
                pos[0] = i;
                pos[1] = j;
            }
        }
    }
    return pos;
}