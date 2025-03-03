string input = Console.ReadLine()!;
Stack<char> stack = new Stack<char>();
bool epic = true;

foreach (var c in input)
{
    if (stack.Count() == 0)
    {
        stack.Push(c);
    }
    else if (c == '/' || c == '<')
    {
        stack.Push(c);
    }
    else if(c =='!')
    {
        if (stack.Peek() == '!')
        {
            stack.Pop();
        }
        else
        {
            stack.Push(c);
        }
    }
    else if (c == '\\')
    {
        if (stack.Peek() == '/')
        {
            stack.Pop();
        }
        else
        {
            epic = false;
            break;
        }
    }
    else if (c == '>')
    {
        if (stack.Peek() == '<')
        {
            stack.Pop();
        }
        else
        {
            epic = false;
            break;
        }
    }
}

if (!epic)
{
    Console.WriteLine("Not Epic");
}
else 
{
    if (stack.Count()==0)
    {
        Console.WriteLine("Epic");
    }
    else
    {
        Console.WriteLine("Not Epic");
    }
}


