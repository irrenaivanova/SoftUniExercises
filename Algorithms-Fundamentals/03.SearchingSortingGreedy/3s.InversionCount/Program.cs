
using System;
using System.Linq;

namespace Sorting
{
    public class Program
    {
        public static void Main(string[] args)
        {

            double[] arr = Console.ReadLine().Split().Select(double.Parse).ToArray();
            int inversions = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j] && i<j)
                    {
                        inversions++;
                    }
                }
            }
            Console.WriteLine(inversions);
        }
    }
}