using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

        int maxSum = int.MinValue;
        int currentSum = 0;
        int startIndex = 0, endIndex = 0, tempStart = 0;
        int maxLength = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            currentSum += numbers[i];

            if (currentSum > maxSum || (currentSum == maxSum && (i - tempStart) > maxLength))
            {
                maxSum = currentSum;
                startIndex = tempStart;
                endIndex = i;
                maxLength = i - tempStart;
            }

            if (currentSum < 0)
            {
                currentSum = 0;
                tempStart = i + 1;
            }
        }

        Console.WriteLine($"{maxSum} {startIndex} {endIndex}");
    }
}

