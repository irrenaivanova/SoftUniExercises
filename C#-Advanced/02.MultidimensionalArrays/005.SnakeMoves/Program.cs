int[] dim = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int row = dim[0];
int col = dim[1];
char[,] matrix = new char[row, col];
string snake = Console.ReadLine();
int lastsymb = 0;

for (int i = 0; i < row; i++)
{
    int n = 0;
    for (int j = 0; j < col; j++)
    {
        int currSymb = j - n * snake.Length + lastsymb;
        matrix[i, j] = snake[currSymb];
        if (j == col - 1)
        {
            if (currSymb == snake.Length - 1)
                lastsymb = 0;
            else
                lastsymb = currSymb + 1;
        }
        if (currSymb == snake.Length - 1)
            n++;
    }
    if (i % 2 == 1)
    {
        char[,] matrixNew = new char[row, col];
        for (int j = 0; j < col; j++)
        {
            matrixNew[i, j] = matrix[i, col - j - 1];
        }
        for (int j = 0; j < col; j++)
        {
            matrix[i, j] = matrixNew[i, j];
        }
    }
}

for (int i = 0; i < row; i++)
{
    for (int j = 0; j < col; j++)
    {
        Console.Write(matrix[i, j]);
    }
    Console.WriteLine();
}
