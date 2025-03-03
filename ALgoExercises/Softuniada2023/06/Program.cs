int[] numbers = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
int maxSum = int.MinValue;
int tempIndex = 0;
int endIndex = 0;
int startIndex = 0;
int maxLength = 0;

int currentSum = 0;

for (int i = 0; i < numbers.Length; i++)
{
    currentSum += numbers[i];

    if (currentSum > maxSum || (currentSum == maxSum && (i-tempIndex) > maxLength))
    {
        maxSum = currentSum;
        startIndex = tempIndex;
        endIndex = i;
        maxLength = i-tempIndex;
    }

    if (currentSum < 0)
    {
        currentSum = 0;
        tempIndex = i + 1;
    }
}


Console.WriteLine($"{maxSum} {startIndex} {endIndex}");