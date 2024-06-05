using System.Text;

List<string> numbers = Console.ReadLine().Split().ToList();

for (int i = 0; i < numbers.Count; i++)
{
    string max = numbers[i];

	for (int j = i+1; j < numbers.Count; j++)
	{
		if (numbers[j].CompareTo(numbers[i]) >0)
		{
			string temp = numbers[j];
			numbers[j] = numbers[i];
			numbers[i] = temp;
		}
	}
}

for (int i = numbers.Count-1; i > 0; i--)
{
	if (numbers[i].Length!= numbers[i-1].Length && numbers[i][0] == numbers[i - 1][0])
	{
		if (numbers[i - 1][1] < numbers[i][0])
		{
			string temp = numbers[i];
			numbers[i] = numbers[i-1];
			numbers[i-1] = temp;

        }
	}
}

StringBuilder result = new StringBuilder();
for (int i = 0; i < numbers.Count; i++)
{
	result.Append(numbers[i]);
}
Console.WriteLine(result);