int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

int count = numbers.Length+1 + (numbers.Length-1)*numbers.Length/2;

for (int i = 0; i < numbers.Length - 2; i++)
{
    int diff = numbers[i + 1] - numbers[i];
    int j = i + 1;
    while (j < numbers.Length - 1 && numbers[j + 1] - numbers[j] == diff)
    {
        count++;
        j++;
    }
}



Console.WriteLine(count); 
    