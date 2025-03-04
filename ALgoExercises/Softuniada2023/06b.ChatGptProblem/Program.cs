List<int> input = Console.ReadLine()!.Split(" ").Select(int.Parse).ToList();

int maxSum = 0;
int currentSum = 0;
int startIndex = 0;
int tempIndex = 0;
int endIndex = 0;

for (int i = 0; i < input.Count; i++)
{
    currentSum += input[i];
    if (currentSum > maxSum)
    {
        maxSum = currentSum;
        endIndex = i;
        startIndex = tempIndex;
    }

    if (currentSum < 0)
    {
        tempIndex = i + 1;
        currentSum = 0;
    }
}





Console.WriteLine($"{maxSum} {startIndex} {endIndex}");
