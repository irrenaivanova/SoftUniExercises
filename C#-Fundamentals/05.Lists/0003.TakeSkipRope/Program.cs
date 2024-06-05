string input = Console.ReadLine();
List<int> numbers = new List<int>();
string nonNumbers = string.Empty;
string final = string.Empty;

for (int i = 0; i < input.Length; i++)
{
    if (Char.IsNumber(input, i))
    {
        int currentNumber = input[i] - 48;
        numbers.Add(currentNumber);
    }
    else
        nonNumbers += input[i];
}

int total = 0;
for (int i = 0; i < numbers.Count; i++)
{
    if (i % 2 == 0)
    {
        if (total + numbers[i] > nonNumbers.Length)
        { numbers[i] = nonNumbers.Length - total - 1; }
        final += nonNumbers.Substring(total, numbers[i]);
        total += numbers[i];
    }
    if (i % 2 == 1)
    {
        total += numbers[i];
    }
}
Console.WriteLine(final);


//Console.WriteLine(string.Join(" ",numbers));
//Console.WriteLine(nonNumbers);
//Console.WriteLine(nonNumbers.Substring(0, 3));