string input = Console.ReadLine();
Stack<int> stack = new Stack<int>();

for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '{')
    {
        stack.Push(input[i]);
    }
    else if (input[i] == '[')
    {
        if (stack.Count == 0)
            stack.Push(input[i]);
        else
        {
            if (stack.Peek() == '{' || stack.Peek() == '[')
                stack.Push(input[i]);
            else
            {
                Console.WriteLine("NO");
                return;
            }
        }
    }
    else if (input[i] == '(')
    {
        if (stack.Count == 0)
            stack.Push(input[i]);
        else
        {
            if (stack.Peek() == '[' || stack.Peek() == '(')
                stack.Push(input[i]);
            else
            {
                Console.WriteLine("NO");
                return;
            }
        }
    }
    else
    {
        if (stack.Any() && input[i] - stack.Peek() < 3)
        {
            stack.Pop();
        }
        else
        {
            Console.WriteLine("NO");
            return;
        }
    }
}
if (stack.Count == 0)
    Console.WriteLine("YES");
else
    Console.WriteLine("NO");