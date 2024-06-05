
using System;
using System.Linq;

namespace Algorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            PrintTheNumber(arr, arr.Length - 1);

            void PrintTheNumber(int[] arr, int start)
            {
                if (start < 0)
                {
                    return;
                }
                Console.Write(arr[start] + " ");
                PrintTheNumber(arr, start - 1);
            }
        }
    }
}
