
using System;
using System.Linq;

namespace Algorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Decreasing('*', n);
            Increasing('#', n, 1);

        }

        private static void Increasing(char sign, int n, int start)
        {
            if (n - start + 1 == 0)
            {
                return;
            }
            Console.WriteLine(new string(sign, start));
            start++;
            Increasing(sign, n, start);
        }

        private static void Decreasing(char sign, int n)
        {
            if (n == 0)
            {
                return;
            }
            Console.WriteLine(new string(sign, n));
            n--;
            Decreasing(sign, n);
        }
    }
}
  

