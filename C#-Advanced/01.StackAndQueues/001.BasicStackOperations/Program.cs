int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
Stack<int> stack = new Stack<int>();
int ifNumber = commands[2];

for (int i = 0; i < commands[0]; i++)
{
    stack.Push(numbers[i]);
}
for (int i = 0; i < commands[1]; i++)
{
    if (stack.Count > 0)
    {
        stack.Pop();
    }
}
if (stack.Count == 0)
{
    Console.WriteLine("0");
    return;
}
if (stack.Contains(ifNumber))
{
    Console.WriteLine("true");
}
else
{
    Console.WriteLine(stack.Min());
}
