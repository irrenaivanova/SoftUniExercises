
using System;
using System.Linq;

namespace Algorithms
{ 
public class Program
{
    public static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int sum = Sum(numbers, 0);

        Console.WriteLine(sum);
        int Sum(int[] numbers, int start)
        {
            if (start == numbers.Length)
            {
                return 0;
            }

            return numbers[start++] + Sum(numbers, start);
        }
    }
}
}