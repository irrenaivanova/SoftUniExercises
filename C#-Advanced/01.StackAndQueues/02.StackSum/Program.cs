int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
Stack<int> numbers = new Stack<int>();
int sum = 0;

foreach (var item in input)
{
    numbers.Push(item);
}
while (true)
{
    string[] commandLine = Console.ReadLine().ToLower().Split();
    string command = commandLine[0];
    if (command == "end")
        break;
    if (command == "add")
    {
        int first = int.Parse(commandLine[1]);
        int second = int.Parse(commandLine[2]);
        numbers.Push(first);
        numbers.Push(second);
    }
    else if (command == "remove")
    {
        int numbersToPop = int.Parse(commandLine[1]);
        if (numbersToPop <= numbers.Count)
        {
            for (int i = 0; i < numbersToPop; i++)
            {
                numbers.Pop();
            }
        }
    }
}
if (numbers.Count == 0)
{
    sum = 0;
}
else
{
    while (numbers.Count > 0)
    {
        sum += numbers.Pop();
    }
}
Console.WriteLine($"Sum: {sum}");