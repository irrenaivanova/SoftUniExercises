List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

while (true)
{
    string command = Console.ReadLine();
    if (command == "end")
        break;
    if (command == "print")
    {
        Console.WriteLine(string.Join(" ", numbers));
    }

    Func<double, double> operation = GetOperation(command);

    numbers = MakeOperation(numbers, operation);
}

List<double> MakeOperation(List<double> numbers, Func<double, double> operation)
{
    for (int i = 0; i < numbers.Count; i++)
    {
        numbers[i] = operation(numbers[i]);
    }
    return numbers;
}

Func<double, double> GetOperation(string command)
{
    if (command == "add")
    {
        return x => x + 1;
    }
    else if (command == "multiply")
    {
        return x => x * 2;
    }
    else if (command == "subtract")
    {
        return x => x - 1;
    }
    else
        return x => x;
}

