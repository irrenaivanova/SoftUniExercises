using Microsoft.VisualBasic;

int n = int.Parse(Console.ReadLine());
int[] max = new int[n];
int maxSum = -1;
int maxCount = -1;
int maxLeftPosition = int.MaxValue;
int bestPosition = -1;

int sampleCount = 1;

while (true)
{
    string command = Console.ReadLine();
    if (command == "Clone them!")
        break;
    //10
    //0!0!1!1!1!0!1!1!1!1
    int[] sample = command.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    int leftPosition = -1;
    int count = 1;
    int maxCountSample = -1;
    int sum = 0;
    bool ifOne = true;

    for (int i = 0; i < sample.Length; i++)
    {
        sum += sample[i];
    }
    for (int i = sample.Length - 1; i > 0; i--)
    {
        if (sample[i] == sample[i - 1] && sample[i] == 1)
        {
            count++;
        }
        else
        {
            ifOne = false;
            if (count > maxCountSample)
            {
                maxCountSample = count;
                leftPosition = i;
            }
            else
                ifOne = true;

            count = 1;
        }
    }
    if (ifOne)
    {
        maxCountSample = count;
        leftPosition = 0;
    }

    if (maxCountSample > maxCount
        || (maxCountSample == maxCount && leftPosition < maxLeftPosition)
        || (maxCountSample == maxCount && leftPosition == maxLeftPosition && sum > maxSum))
    {
        maxLeftPosition = leftPosition;
        maxCount = maxCountSample;
        max = sample;
        maxSum = sum;
        bestPosition = sampleCount;

    }
    sampleCount++;
}
Console.WriteLine($"Best DNA sample {bestPosition} with sum: {maxSum}.");
Console.WriteLine(string.Join(" ", max));
