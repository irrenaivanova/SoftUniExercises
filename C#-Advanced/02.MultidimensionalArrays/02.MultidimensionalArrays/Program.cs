using System.Numerics;

int[] rowsCoumns = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
int[,] matrix = new int[rowsCoumns[0], rowsCoumns[1]];
int sum = 0;
for (int i = 0; i < rowsCoumns[0]; i++)
{
    int[] currentColums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
    for (int j = 0; j < rowsCoumns[1]; j++)
    {
        matrix[i, j] = currentColums[j];
        sum += currentColums[j];
    }
}
Console.WriteLine(rowsCoumns[0]);
Console.WriteLine(rowsCoumns[1]);
Console.WriteLine(sum);