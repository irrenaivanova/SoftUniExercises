int n = int.Parse(Console.ReadLine());
Dictionary<int, int> numbers = new Dictionary<int, int>();

for (int i = 0; i < n; i++)
{
    int newNumber = int.Parse(Console.ReadLine());
    if (!numbers.ContainsKey(newNumber))
    {
        numbers.Add(newNumber, 0);
    }
    numbers[newNumber]++;
}
foreach (var number in numbers)
{
    if (number.Value % 2 == 0)
    {
        Console.WriteLine(number.Key);
        break;
    }
}
