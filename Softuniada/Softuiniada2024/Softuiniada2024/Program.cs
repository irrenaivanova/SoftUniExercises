int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

int max = int.MinValue;

for (int i = 1; i < numbers.Length-1; i++)
{
    if (numbers[i]>numbers[i + 1]  && numbers[i] > numbers[i - 1] && numbers[i]>max)
    {
        max = numbers[i];
    }
}
Console.WriteLine(max);