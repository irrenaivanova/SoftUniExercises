
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            List<string> list =  PrintComp(arr, 0);

            Console.WriteLine();

        }

        private static List<string> PrintComp(int[] arr, int start)
        {
            List<string> list = new();

            for (int i = 0; i < 2; i++)
            {
                if (start >= arr.Length)
                {
                    Console.WriteLine(string.Join(string.Empty, arr));
                    return new() {string.Join(string.Empty, arr)};
                }
                arr[start] = i;
                list.AddRange(PrintComp(arr, start + 1));
            }
            return list;
        }
    }
}


//return new[] { arr[start] };