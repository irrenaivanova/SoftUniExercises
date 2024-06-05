using System.Reflection;

int n = int.Parse(Console.ReadLine());

char[,] matrix = new char[n,n];
int battle = 0;
int mines = 0;

for (int i = 0; i < n; i++)
{
	string input = Console.ReadLine();

    for (int j = 0; j < n; j++)
	{
		matrix[i,j] = input[j];
	}
}

int[] position = new int[2];

for (int i = 0; i < n; i++)
{
	for (int j = 0; j < n; j++)
	{
		if (matrix[i,j]=='S')
		{
			position[0] = i;
			position[1] = j;
        }
	}
}

matrix[position[0], position[1]] = '-';
while (true)
{
	string command = Console.ReadLine();
	position = Move(position,command);
	
	if (matrix[position[0], position[1]]=='*')
	{
		mines++;
		if (mines==3)
		{
            Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{position[0]}, {position[1]}]!");
            matrix[position[0], position[1]] = 'S';
            break;
        }  
    }
    if (matrix[position[0], position[1]] == 'C')
    {
		battle++;
        if (battle==3)
		{
            Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
            matrix[position[0], position[1]] = 'S';
            break;
        }
    }
	matrix[position[0], position[1]] = '-';
}
PrintTheMatrix(matrix);

int[] Move(int[] position, string command)
{
    switch(command)
	{
		case "down":
			position[0] += 1;break;
        case "up":
            position[0] -= 1; break;
        case "left":
            position[1] -= 1; break;
        case "right":
            position[1] += 1; break;
    }
	return position;
}

void PrintTheMatrix(char[,] matrix)
{
	for (int i = 0; i < matrix.GetLength(0); i++)
	{
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i,j]);
        }
        Console.WriteLine();
    }
}