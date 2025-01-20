string input = Console.ReadLine();
Stack<int> stack = new Stack<int>();
List<string> output = new List<string>();


for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '(')
    {
        stack.Push(i);
    }

    if (input[i] == ')')
    {
        if (!stack.Any())
        {
            Console.WriteLine("Unbalanced");
            break;
        }
        int index = stack.Pop();
        output.Add(input.Substring(index + 1, i - index - 1));
    }
}
if (stack.Any())
{
    Console.WriteLine("Unbalanced");
    return;
}
Console.WriteLine(string.Join("\n",output));