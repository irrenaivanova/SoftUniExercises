string input = Console.ReadLine();
Stack<char> stack = new Stack<char>();
bool isBalanced = true;
bool isFirst = false;
for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '(' || input[i] == '[' || input[i] == '{')
    {
        if (stack.Any() && (int)stack.Peek() < (int)(input[i]))
        {
            isBalanced = false;
            break;
        }
        stack.Push(input[i]);
    }

    else if (input[i] == ')' || input[i] == ']' || input[i] == '}')
    {
        if (stack.Any() && Math.Abs((int)(input[i]) - (int)stack.Peek()) > 2 || !stack.Any())
        {
            isBalanced = false;
            break;
        }
        char c = stack.Pop();
        if (c == '(')
        {
            isFirst = true;
        }
        if ((c == '[' || c == '{') && !isFirst)
        {
            isBalanced = false;
            break;
        }

        if (stack.Any() && c == '(' && stack.Peek() == '{')
        {
            isBalanced = false;
            break;
        }
    }
    else
    {
        isBalanced = false;
        break;
    }
}
if (stack.Any())
{
    isBalanced = false;
}

if (!isBalanced)
{
    Console.WriteLine("NO");
}
else
{
    Console.WriteLine("YES");
}