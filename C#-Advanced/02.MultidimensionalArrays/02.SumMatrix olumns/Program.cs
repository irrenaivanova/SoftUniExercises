using System.Numerics;

int[] rowsCoumns = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
int[,] matrix = new int[rowsCoumns[0], rowsCoumns[1]];
int[] sumColumns = new int[rowsCoumns[1]];
for (int i = 0; i < rowsCoumns[0]; i++)
{
    int[] currentColums = Console.ReadLine().Split().Select(int.Parse).ToArray();
    for (int j = 0; j < rowsCoumns[1]; j++)
    {
        matrix[i, j] = currentColums[j];
    }
}
for (int i = 0; i < rowsCoumns[1]; i++)
{
    int currCol = 0;
    for (int j = 0; j < rowsCoumns[0]; j++)
    {
        currCol += matrix[j, i];
    }
    sumColumns[i] = currCol;
}
Console.WriteLine(string.Join("\n", sumColumns));