
using System;
using System.Linq;

namespace Algorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Printing(n);
  
        }

        private static void Printing(int n)
        {
            if (n == 0)
            {
                return;
            }
            Console.WriteLine(new string('*', n));
            Printing(n-1);
            Console.WriteLine(new string('#',n));
        }
    }
}


