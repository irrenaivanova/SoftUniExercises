//3 14 5 12 15 7 8 9 11 10 1

int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[,] matrix = new int[3, nums.Length];

for (int i = 0; i < nums.Length; i++)
{
    matrix[0, i] = nums[i];
}

for (int i = 1; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = -2;
    }
}

matrix[1, 0] = 1;
matrix[2, 0] = -1;

for (int i = 1; i < nums.Length; i++)
{
    for (int j = i-1; j >= 0; j--)
    {
        if (matrix[0,i] > matrix[0,j])
        {
            matrix[1, i] = matrix[1, j] + 1;
            matrix[2,i] = j;
            break;
        }
        if (matrix[0, i] == matrix[0, j])
        {
            matrix[1, i] = matrix[1, j];
            matrix[2, i] = matrix[2, j];
            break;
        }
        if (matrix[0, i] < matrix[0, j])
        {
            continue;
        }
    }

    if  (matrix[1, i]==-2)
    {
        matrix[1, i] = 1;
        matrix[2,i] = -1;
    }
}
Stack<int> theNumbers = new();
int maxPos = 0;
int maxLength = matrix[1, 0];
for (int i = 1; i < nums.Length; i++)
{
    if (matrix[1, i]> maxLength)
    {
        maxLength = matrix[1, i];
        maxPos = i;
    }
}
Console.WriteLine($"Length: {maxLength}");

int position = maxPos;
while (true)
{
     if (position==-1)
    {
        break;
    }
    theNumbers.Push(matrix[0, position]);
    position = matrix[2, position];
}
Console.WriteLine(string.Join(" ",theNumbers));




PrintTheMatrix(matrix);

void PrintTheMatrix(int[,] matrix)
{
	for (int i = 0; i < matrix.GetLength(0); i++)
	{
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i,j]+"   ");
        }
        Console.WriteLine();
    }
}