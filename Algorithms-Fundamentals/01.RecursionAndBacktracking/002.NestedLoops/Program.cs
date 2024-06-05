
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

            List<string> combinations = PrintTheCombinations(arr,0);
            
            foreach (var comb in combinations)
            {
                Console.WriteLine(comb);
            }

        }

       public static List<string> PrintTheCombinations(int[] arr,int start)
        {
            List<string> combin = new();
           
            for (int i = 1; i <= arr.Length; i++)
            {
                if (start == arr.Length)
                {
                    return new() { string.Join(" ",arr)};
                }
                arr[start] = i;
                combin.AddRange(PrintTheCombinations(arr, start + 1));
                
            }
            return combin;
        }
    }
}
