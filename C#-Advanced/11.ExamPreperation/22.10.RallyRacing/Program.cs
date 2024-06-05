using System.Security.Cryptography;

int n = int.Parse(Console.ReadLine());
string numberCar = Console.ReadLine();
int distance = 0;

int[] currPos = new int[2] {0,0};

string[][] matrix = ReadTheMatrix(n);

while(true)
{
	string move = Console.ReadLine();
    if (move == "End")
    {
        matrix[currPos[0]][currPos[1]] = "C";
        Console.WriteLine($"Racing car {numberCar} DNF.");
        break;
    }
	currPos = MovePosition(currPos,move);
    distance += 10;
    
    if (matrix[currPos[0]][currPos[1]]=="F")
    {
        matrix[currPos[0]][currPos[1]] = "C";
        Console.WriteLine($"Racing car {numberCar} finished the stage!");
        break;
    }

    if (matrix[currPos[0]][currPos[1]] == "T")
    {
        distance += 20;
        currPos = FindTheNextT(matrix, currPos);
    }
}
Console.WriteLine($"Distance covered {distance} km.");
PrintTheMatrix(matrix);

int[] FindTheNextT(string[][] matrix, int[] currPos)
{
    int[] newPos = new int[2];
    for (int i = 0; i < matrix.Length; i++)
    {
        for (int j = 0; j < matrix.Length; j++)
        {
            if (matrix[i][j]=="T" && (i != currPos[0] || j!= currPos[1]))
            {
                newPos[0] = i;
                newPos[1] = j;
            }
        }
    }

    matrix[currPos[0]][currPos[1]] = ".";
    matrix[newPos[0]][newPos[1]] = ".";
    return newPos;
}


int[] MovePosition(int[] currPos, string move)
{
	if (move=="down")
	{
        currPos[0] += 1;
	}
    if (move == "up")
    {
        currPos[0] -= 1;
    }
    if (move == "left")
    {
        currPos[1] -= 1;
    }
    if (move == "right")
    {
        currPos[1] += 1;
    }
    return currPos;
}

void PrintTheMatrix(string[][] matrix)
{
    for (int i = 0; i < n; i++)
    {
        Console.WriteLine(string.Join("", matrix[i]));
    }
    Console.WriteLine();
}

string[][] ReadTheMatrix(int n)
{
	string[][] matrix = new string[n][];	
	
	for (int i = 0; i < n; i++)
	{
		string[] row = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
        matrix[i] = new string[row.Length];
        
		for (int j = 0; j< row.Length; j++)
		{
			matrix[i][j] = row[j];
		}
	}
	return matrix;
}