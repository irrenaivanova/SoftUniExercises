﻿string input = Console.ReadLine();
Stack<int> stack = new Stack<int>();

for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '(')
    {
        stack.Push(i);
    }
    else if (input[i] == ')')
    {
        while (stack.Count > 0)
        {
            int start = stack.Pop();
            Console.WriteLine(input.Substring(start, i - start + 1));
            break;
        }
    }
}
