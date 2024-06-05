
using System;
using System.Linq;

namespace Algorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            Console.WriteLine(FindTheQueens(matrix, 0)); 
           
        }

        private static int FindTheQueens(int[,] matrix, int row)
        {
            if (row==matrix.GetLength(0)) 
            {
                PrintTheMatrix(matrix);
                return 1;
            }
            int foundQueens = 0;

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (IsSafe(matrix,row,col))
                {
                    matrix[row, col] = 1;
                    foundQueens += FindTheQueens(matrix, row + 1);
                    matrix[row, col] = 0;
                }
            }
            return foundQueens;
        }

        private static bool IsSafe(int[,] matrix, int row, int col)
        {
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (row-i>=0 && matrix[row-i,col]==1)
                {
                    return false;
                }
                if (col - i >=0 && matrix[row, col - i] == 1)
                {
                    return false;
                }
             
                if (col - i >=0 && row - i >= 0 && matrix[row - i, col - i] == 1)
                {
                    return false;
                }
                if (col + i < matrix.GetLength(0) && row - i >= 0 && matrix[row - i, col + i] == 1)
                {
                    return false;
                }
            }
            return true;
        }

        static void PrintTheMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}