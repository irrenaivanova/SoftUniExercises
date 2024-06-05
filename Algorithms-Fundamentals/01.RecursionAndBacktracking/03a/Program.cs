using System;
using System.Linq;

namespace Algorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            PrintComp(arr, 0);
        }

        private static void PrintComp(int[] arr, int start)
        {
            for (int i = 0; i < 2; i++)
            {
                if (start>=arr.Length)
                {
                    Console.WriteLine(string.Join(string.Empty,arr));
                    return;
                }
                arr[start] = i;
                PrintComp(arr, start + 1);
            }
        }
    }
}


