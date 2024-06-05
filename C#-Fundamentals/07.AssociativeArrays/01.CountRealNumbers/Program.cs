List<double> input = Console.ReadLine().Split().Select(double.Parse).ToList();

SortedDictionary<double, int> list = new SortedDictionary<double, int>();

for (int i = 0; i < input.Count; i++)
{
    double currentNumber = input[i];

    if (!list.ContainsKey(input[i]))
        list.Add(currentNumber, 1);
    else
        list[input[i]]++;
}
foreach (var item in list)
{
    Console.WriteLine($"{item.Key} -> {item.Value}");
}