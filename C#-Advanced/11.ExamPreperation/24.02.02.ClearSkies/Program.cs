int n   = int.Parse(Console.ReadLine());

char[,] matrix = new char[n,n];

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
	for (int j = 0; j < n; j++)
	{
		matrix[i, j] = input[j];
	}
}

int armour = 300;
int enemyPlanes = 0;
int[] jetPos=new int[n];

for (int i = 0; i < n; i++)
{
	for (int j = 0; j < n; j++)
	{
		if (matrix[i, j]=='E')
		{
			enemyPlanes++;
		}
		if (matrix[i, j] == 'J')
		{
			jetPos[0] = i;
            jetPos[1] = j;
        }
	}
}

matrix[jetPos[0], jetPos[1]] = '-';

while(true)
{
	string direction = Console.ReadLine();
	jetPos = MoveTheJet(jetPos, direction);
	if (matrix[jetPos[0], jetPos[1]] == 'E')
	{
		enemyPlanes--;
		if(enemyPlanes == 0)
		{
            Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
			matrix[jetPos[0], jetPos[1]] = 'J';
			break;
        }
		armour -= 100;

		if (armour == 0)
		{
            Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{jetPos[0]}, {jetPos[1]}]!");
            matrix[jetPos[0], jetPos[1]] = 'J';
            break;
        }
	}
    if (matrix[jetPos[0], jetPos[1]] == 'R')
    {
		armour = 300;
    }

    matrix[jetPos[0], jetPos[1]] = '-';
}

PrintTheMatrix(matrix, n);
int[] MoveTheJet(int[] jetPos, string? direction)
{
	if (direction=="right")
	{
		jetPos[1] += 1;
	}
    if (direction == "left")
    {
        jetPos[1] -= 1;
    }
    if (direction == "up")
    {
        jetPos[0] -= 1;
    }
    if (direction == "down")
    {
        jetPos[0] += 1;
    }

    return jetPos;
}



void PrintTheMatrix(char[,] matrix, int n)
{
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			Console.Write(matrix[i,j]);
        }
        Console.WriteLine();
    }
}