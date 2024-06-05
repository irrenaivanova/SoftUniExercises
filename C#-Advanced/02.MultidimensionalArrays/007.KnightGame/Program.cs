int n = int.Parse(Console.ReadLine());
char[,] matrix = new char[n + 4, n + 4];

for (int i = 2; i < n + 2; i++)
{
    string input = Console.ReadLine();

    for (int j = 2; j < n + 2; j++)
    {
        matrix[i, j] = input[j - 2];
    }
}

List<int[]> moves = new List<int[]>();
moves.Add(new int[] { 1, 2 });
moves.Add(new int[] { 1, -2 });
moves.Add(new int[] { -1, 2 });
moves.Add(new int[] { -1, -2 });
moves.Add(new int[] { 2, -1 });
moves.Add(new int[] { 2, 1 });
moves.Add(new int[] { -2, -1 });
moves.Add(new int[] { -2, 1 });



int totalCount = 0;

for (int a = 8; a > 0; a--)
{
    int currCount = 0;

    for (int i = 2; i < n + 2; i++)
    {
        for (int j = 2; j < n + 2; j++)
        {
            if (matrix[i, j] == 'K')
            {
                foreach (int[] move in moves)
                {
                    if (matrix[i + move[0], j + move[1]] == 'K')
                    {
                        currCount++;
                    }
                }
                if (currCount == a)
                {
                    matrix[i, j] = '0';
                    totalCount++;
                }
                currCount = 0;
            }
            else
                continue;
        }
    }
}

Console.WriteLine(totalCount);
//for (int i = 0; i < n + 4; i++)
//{
//    for (int j = 0; j < n + 4; j++)
//    {
//        Console.Write(matrix[i, j] + " ");
//    }
//    Console.WriteLine();
//}