using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arrive = Console.ReadLine().Split().Select(double.Parse).Select(x => (int)(x * 100 / 10)).ToArray();
            int[] depart = Console.ReadLine().Split().Select(double.Parse).Select(x => (int)(x * 100 / 10)).ToArray();

            bool[,] matrix = new bool[arrive.Length, 240];

            for (int i = 0; i < arrive.Length; i++)
            {
                int arrTime = arrive[i];
                int depTime = depart[i];

                bool isMidnight = false;
                int newDepTime = 0;
                if (depTime < arrTime)
                {
                    isMidnight = true;
                }
                if (isMidnight)
                {
                    newDepTime = depTime;
                    depTime = 240;
                }

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (isMidnight)
                    {
                        if (IsFree(matrix, j, arrTime, depTime) && IsFree(matrix, j, 0, newDepTime))
                        {
                            FillIt(matrix, j, arrTime, depTime);
                            FillIt(matrix, j, 0, newDepTime);
                        }
                    }
                    if (IsFree(matrix, j, arrTime, depTime))
                    {
                        FillIt(matrix, j, arrTime, depTime);
                        break;
                    }
                }
            }
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j])
                    {
                        count++;
                        break;
                    }
                }
            }

            Console.WriteLine(count);
        }

        private static void FillIt(bool[,] matrix, int j, int arrTime, int depTime)
        {
            for (int i = arrTime; i <= depTime - 1; i++)
            {
                matrix[j, i] = true;
            }
        }

        private static bool IsFree(bool[,] matrix, int j, int arrTime, int depTime)
        {
            for (int i = arrTime; i <= depTime - 1; i++)
            {
                if (matrix[j, i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}