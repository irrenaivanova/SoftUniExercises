int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

int currLength = 1;
int maxLength = 0;
int tempIndex = numbers.Length-1;
int startIndex = 0;


for (int i = numbers.Length-1; i > 0 ; i--)
{
    if (numbers[i] == numbers[i - 1])
    {
        currLength++;
        if (currLength >= maxLength)
        {
            maxLength = currLength;
            startIndex = tempIndex;
        }

    }
    else
    {
        currLength = 1;
        tempIndex = i - 1;
    }
}

for (int i = 0; i < maxLength ; i++)
{
    Console.Write($"{numbers[startIndex]} ");
}