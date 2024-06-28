int n = int.Parse(Console.ReadLine());
char[,] matrix = new char[n, n];
int energy = 15;
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

while(true)
{
    matrix[position[0], position[1]] = '-';
    string command = Console.ReadLine();
    MoveTheBee(command);
    energy--;
    char current = matrix[position[0], position[1]];

    if (Char.IsDigit(current))
    {
        nectar += current - 48;
        
        if (energy==0 && nectar<30)
        {
            matrix[position[0], position[1]] = 'B';
            Console.WriteLine($"This is the end! Beesy ran out of energy.");
            PrintTheMatrix();
            return;
        }
        if (energy == 0 && nectar == 30)
        {
            matrix[position[0], position[1]] = '-';
            int adding = nectar - 30;
            energy += adding+15;
            restoredLifes = 1;
            continue;
        }
        if (energy==0 && nectar>30)
        {
            if (restoredLifes==0)
            {
                int adding = nectar - 30;
                energy += adding+15;
                restoredLifes = 1;
            }
            if (restoredLifes==1)
            {
                matrix[position[0], position[1]] = 'B';
                Console.WriteLine($"This is the end! Beesy ran out of energy.");
                PrintTheMatrix();
                return;
            }
        }
        matrix[position[0], position[1]] = '-';  
    }
    
    else if (current=='-')
    {
        if (energy == 0 && nectar <= 30)
        {
            matrix[position[0], position[1]] = 'B';
            Console.WriteLine($"This is the end! Beesy ran out of energy.");
            PrintTheMatrix();
            return;
        }
        if (energy == 0 && nectar > 30)
        {
            if (restoredLifes == 0)
            {
                int adding = nectar - 30;
                energy += adding;
                restoredLifes = 1;
            }
            else if (restoredLifes == 1)
            {
                matrix[position[0], position[1]] = 'B';
                Console.WriteLine($"This is the end! Beesy ran out of energy.");
                PrintTheMatrix();
                return;
            }
        }
    }

    else if(current=='H')
    {
        matrix[position[0], position[1]] = 'B';
        if (nectar>=30)
        {
            Console.WriteLine($"Great job, Beesy! The hive is full. Energy left: {energy}");
            PrintTheMatrix();
            return;
        }
        else
        {
            Console.WriteLine("Beesy did not manage to collect enough nectar.");
            PrintTheMatrix();
            return;
        }    
    }
}



void MoveTheBee(string command)
{
    if (command == "up")
    {
        position[0]--;
        if (position[0]<0)
        {
            position[0] = n - 1;
        }
    }
    if (command == "down")
    {
        position[0]++;
        if (position[0] >= n)
        {
            position[0] = 0;
        }
    }
    if (command == "left")
    {
        position[1]--;
        if (position[1] < 0)
        {
            position[1] = n - 1;
        }
    }
    if (command == "right")
    {
        position[1]++;
        if (position[1] >= n)
        {
            position[1] = 0;
        }
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