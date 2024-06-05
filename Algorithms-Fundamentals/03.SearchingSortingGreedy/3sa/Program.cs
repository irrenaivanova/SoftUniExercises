
using System;
using System.Linq;

namespace Sorting
{
    public class Program
    {
        public static void Main(string[] args)
        {

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            (int[] arrSort, int interactions) = MergeSort(arr, 0, arr.Length - 1);


            Console.WriteLine(string.Join(" ", arrSort));
            Console.WriteLine(interactions);

        }

        public static (int[], int) MergeSort(int[] arr, int start, int end)
        {
            if (start == end)
            {
                return (new[] { arr[start] }, 0);
            }

            int middle = (start + end) / 2;

            (int[] left, int inLeft) = (MergeSort(arr, start, middle).Item1, +MergeSort(arr, start, middle).Item2);
            (int[] right, int inRight) = (MergeSort(arr, middle + 1, end).Item1, +MergeSort(arr, middle + 1, end).Item2);

            int[] merged = new int[left.Length + right.Length];

            int a = 0;
            int b = 0;
            //bool firstTime = true;

            for (int i = 0; i < merged.Length; i++)
            {
                if (a == left.Length)
                {
                    merged[i] = right[b];
                    b++;
                    continue;
                }
                if (b == right.Length)
                {
                    merged[i] = left[a];
                    inLeft += right.Length;
                    a++;
                    continue;
                }
                if (left[a] <= right[b])
                {
                    merged[i] = left[a];
                    a++;
                }
                else
                {
                    //if (firstTime)
                    //{
                    //    inLeft += left.Length - i;
                    //}
                    inLeft += left.Length - i;
                    merged[i] = right[b];
                    b++;
                    //firstTime = true;
                }
            }

            return (merged, inLeft);
        }
    }

}