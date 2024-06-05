

using System;
using System.Linq;

namespace Algorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(RecursiveFactoriel(n));
        }

        private static int RecursiveFactoriel(int n)
        {
            if (n==0)
                return 1;

            return n * RecursiveFactoriel(n - 1);
        }
    }
}