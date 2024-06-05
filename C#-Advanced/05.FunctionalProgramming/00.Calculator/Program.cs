int result = 0;

while (true)
{
    Console.WriteLine("Operation:");
    string operationType = Console.ReadLine();
    Console.WriteLine("Value:");
    int operand = int.Parse(Console.ReadLine());

    Func<int, int, int> operation = GetOperation(operationType);

    result = Calculate(operation, result, operand);
    Console.WriteLine(result);
}
Func<int, int, int> GetOperation(string operationType)
{
    switch(operationType)
    {
        case "+": return (x,y)=> x + y;
        case "-": return (x, y) => x - y;
        case "/": return (x, y) => x / y;
        case "*": return (x, y) => x * y;
        default: return null;
    }
}
int Calculate(Func<int, int, int> operation, int result, int operand)
{
    Console.WriteLine($"The result between {result} and {operand} is:");
    return operation(result,operand);
}

