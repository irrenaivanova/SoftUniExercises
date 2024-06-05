using System;
using System.Linq;

namespace Algorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
            string combination = string.Empty;
            PrintingCombination(n,combination,0);
            
        }
        private static void PrintingCombination(int n, string combination,int start)
        {
          
            for (int i = 0; i < 2; i++)
            {
                if (combination.Length == n)
                {
                    Console.WriteLine(combination);
                    return;
                }
                combination += i.ToString();
                PrintingCombination(n, combination,start + 1); 
            }
        }
    }
}


