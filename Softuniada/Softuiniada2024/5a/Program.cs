int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

int count = numbers.Length + 1 + (numbers.Length - 1) * numbers.Length / 2;

for (int m = 0; m < numbers.Length; m++)
{
    for (int i = 0; i < numbers.Length - (2+m); i++)
    {
        int diff = numbers[i + 1+m] - numbers[i+m];
        int j = i + 1+m;
        while (j < numbers.Length - (1+m) && numbers[j +1+ m] - numbers[j] == diff)
        {
            count++;
            j++;
        }
    }
}

Console.WriteLine(count);

