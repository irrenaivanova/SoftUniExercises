int n = int.Parse(Console.ReadLine());
int[][] matrix= new int[n][];

for (int i = 0; i < n; i++)
{
    matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
}

int[][] newMatrix = new int[n][];
for (int i = 0; i < n; i++)
{
    newMatrix[i] = new int[n];

    for (int j = 0; j < n; j++)
    { 
		newMatrix[i][j] = matrix[n-1- j][i];
	}
}

for (int i = 0; i < n; i++)
{
    Console.WriteLine(string.Join(" ", newMatrix[i]));
}