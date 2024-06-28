int n = int.Parse(Console.ReadLine());
char[,] matrix = new char[n, n];
int energy = 3;
int restoredLifes = 0;
int nectar = 0;

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
    matrix[position[0], position[1]] = '-';
    energy--;
    MoveTheBee(command);

    if (IfTheBeeIsGone())
    {
        MoveTheBeeToTheNewPosition();
    }

    if (Char.IsDigit(matrix[position[0], position[1]]))
    {
        nectar += matrix[position[0], position[1]] - 48;
        matrix[position[0], position[1]] = '-';
       
        if (energy == 0 && nectar < 30)
        {
            matrix[position[0], position[1]] = 'B';
            Console.WriteLine($"This is the end! Beesy ran out of energy.");
            PrintTheMatrix();
            return;
        }
        if (energy == 0 && nectar >= 30)
        {
            if (restoredLifes == 0)
            {
                restoredLifes = 1;
                energy += nectar - 30;
                nectar = 30;
            }
            if (restoredLifes == 1)
            {
                matrix[position[0], position[1]] = 'B';
                Console.WriteLine($"This is the end! Beesy ran out of energy.");
                PrintTheMatrix();
                return;
            }
        }
    }

    if (matrix[position[0], position[1]] == 'H')
    {
        matrix[position[0], position[1]] = 'B';
        if (nectar >= 30)
        {
            Console.WriteLine($"Great job, Beesy! The hive is full. Energy left: {energy}");
            PrintTheMatrix();
            return;
        }
        Console.WriteLine("Beesy did not manage to collect enough nectar.");
        PrintTheMatrix();
        return;
    }

    if (matrix[position[0], position[1]] == '-')
    {
        if (energy == 0)
        {
            matrix[position[0], position[1]] = 'B';
            Console.WriteLine($"This is the end! Beesy ran out of energy.");
            PrintTheMatrix();
            return;
        }
    }
}

void MoveTheBeeToTheNewPosition()
{
    if (position[1]>=n)
    {
        position[1] = 0;
    }
    
    if (position[1] <0)
    {
        position[1] = n-1;
    }
    if (position[0] < 0)
    {
        position[0] = n - 1;
    }
    if (position[0] >=n)
    {
        position[0] = 0;
    }
}


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
    if (command == "up")
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
            Console.Write(matrix[i, j]);
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