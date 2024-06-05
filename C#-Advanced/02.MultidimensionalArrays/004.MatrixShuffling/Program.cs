int[] dim = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int row = dim[0];
int col = dim[1];

string[,] matrix = new string[row, col];

for (int i = 0; i < row; i++)
{
    string[] curr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    for (int j = 0; j < col; j++)
    {
        matrix[i, j] = curr[j];
    }
}

while (true)
{
    string[] command = Console.ReadLine().Split();
    if (command[0] == "END")
        break;
    if (command[0] != "swap" || command.Length != 5)
    {
        Console.WriteLine("Invalid input!");
        continue;
    }
    int x1 = int.Parse(command[1]);
    int y1 = int.Parse(command[2]);
    int x2 = int.Parse(command[3]);
    int y2 = int.Parse(command[4]);
    if (x1 < 0 || x2 < 0 || y1 < 0 || y2 < 0 || x1 >= row || x2 >= row || y1 >= col || y2 >= col)
    {
        Console.WriteLine("Invalid input!");
        continue;
    }
    string temp = matrix[x1, y1];
    matrix[x1, y1] = matrix[x2, y2];
    matrix[x2, y2] = temp;
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}