List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
List<int> newNumbers = new List<int>();

for (int i = 0; i < numbers.Count / 2f; i++)
{
    if (i != numbers.Count - 1 - i)
        newNumbers.Add(numbers[i] + numbers[numbers.Count - 1 - i]);
    else
        newNumbers.Add(numbers[i]);
}
Console.WriteLine(string.Join(" ", newNumbers));