
int[,] sudoku = new int[,]
{
    {5,3,0,0,7,0,0,0,0 },
    {6,0,0,1,9,5,0,0,0 },
    {0,9,8,0,0,0,0,6,0 },
    {8,0,0,0,6,0,0,0,3 },
    {4,0,0,8,0,3,0,0,1 },
    {7,0,0,0,2,0,0,0,6 },
    {0,6,0,0,0,0,2,8,0 },
    {0,0,0,4,1,9,0,0,5 },
    {0,0,0,0,8,0,0,7,9 },
};

//bool solution = SolveTheSudoku(0,0);

SolveTheSudoku(0, 0);
void SolveTheSudoku(int row, int col)
{
    if (row == sudoku.GetLength(1))
    {
        Print();
        Environment.Exit(0);
    }

    if (row < sudoku.GetLength(0) && col == sudoku.GetLength(1))
    {
       SolveTheSudoku(row + 1,0);
       return;
    }

    if (sudoku[row, col] == 0)
    {
        for (int k = 1; k <= 9; k++)
        {
            if (IsSafe(row, col, k))
            {
                sudoku[row, col] = k;
                SolveTheSudoku(row, col + 1);

                sudoku[row, col] = 0;
            }
        }
    }

    else
    {
        SolveTheSudoku(row, col + 1);
    }

}

bool IsSafe(int row, int col, int k)
{
    for (int i = 0; i < sudoku.GetLength(0); i++)
    {
        if (sudoku[i,col]==k)
        {
            return false;
        }

        if (sudoku[row, i] == k)
        {
            return false;
        }
    }
    int[] deviationRow = FindDeviation(row);
    int[] deviationCol = FindDeviation(col);

    for (int i = 0; i < deviationRow.Length; i++)
    {
        for (int j = 0; j < deviationCol.Length; j++)
        {
            int rowCheck = row + deviationRow[i];
            int colCheck = col + deviationCol[j];

            if (sudoku[rowCheck, colCheck] == k)
            {
                return false;
            }
        }
    }

    return true;
}

int[] FindDeviation(int index)
{
    if (index % 3 == 0)
    {
        return new int[] { 0, 1, 2 };
    }

    if (index % 3 == 1)
    {
        return new int[] { -1, 0, 1 };
    }

    return new int[] { -2, -1, 0 };
}

void Print()
{
    for (int i = 0; i < sudoku.GetLength(0); i++)
    {
        for (int j = 0; j < sudoku.GetLength(1); j++)
        {
            Console.Write($"{sudoku[i,j]} ");
            if (j % 3 == 2)
            {
                Console.Write("|");
            }
        }

        Console.WriteLine();
        if (i %3 == 2)
        {
            Console.WriteLine(new string('_',20));
        }
    }
}