using System.Data.Common;
using System.Globalization;

int n = int.Parse(Console.ReadLine());
int row =  int.Parse(Console.ReadLine());
int col =  int.Parse(Console.ReadLine());
int rowF =  int.Parse(Console.ReadLine());
int colF= int.Parse(Console.ReadLine());

List<int> paths = new();

int[,] matrix = new int[n,n];
bool[,] visited = new bool[n,n]; 


FindThePath(matrix, row, col, visited, 0);

void FindThePath(int[,] matrix, int row, int col, bool[,] visited, int number)
{

   if (row==rowF && col==colF)
    {
        paths.Add(number);
        return;
    }

    visited[row, col] = true;
    if (IsSafe(matrix, row + 1, col - 2, visited, number + 1))
    {
        FindThePath(matrix, row + 1, col - 2, visited, number + 1);
    }
    if (IsSafe(matrix, row + 2, col + 1, visited, number + 1))
    {
        FindThePath(matrix, row + 2, col + 1, visited, number + 1);
    }
   
    if (IsSafe(matrix, row - 2, col + 1, visited, number + 1))
    {
        FindThePath(matrix, row - 2, col + 1, visited, number + 1);
    }

    if (IsSafe(matrix, row - 1, col - 2, visited, number + 1))
    {
        FindThePath(matrix, row-1, col-2, visited, number + 1);
    }
    if (IsSafe(matrix, row - 2, col - 1, visited, number + 1))
    {
        FindThePath(matrix, row-2, col-1, visited, number + 1);
    }
    
    if (IsSafe(matrix, row - 1, col + 2, visited, number + 1))
    {
        FindThePath(matrix, row-1, col+2, visited, number + 1);
    }
    
    if (IsSafe(matrix, row + 2, col - 1, visited, number + 1))
    {
        FindThePath(matrix, row+2, col-1, visited, number + 1);
    }
   
    if (IsSafe(matrix, row + 1, col + 2, visited, number + 1))
    {
        FindThePath(matrix, row+1, col+2, visited, number + 1);
    }

    visited[row, col] = false;
}
if (paths.Any())
{
    Console.WriteLine(paths.OrderBy(x => x).First());
}
else
    Console.WriteLine();

bool IsSafe(int[,] matrix, int row, int col, bool[,] visited,int number)
{
    if (row < 0 || col < 0 || row >= matrix.GetLength(0) ||
                col >= matrix.GetLength(1))
    {
        return false;
    }
    if (visited[row, col])
    {
        return false;
    }
    if (paths.Any() && (paths.OrderBy(x => x).First()<number || number>2*n))
    {
        return false;
    }
    return true;
}