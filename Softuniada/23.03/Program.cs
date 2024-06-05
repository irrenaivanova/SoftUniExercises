string input = Console.ReadLine();
int max = -1;
int current = 0;
bool isStart = false;
bool stop = false;
Stack<char> stack = new Stack<char>();

for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '(')
    {
        if (stack.Count == 0)
        {
            stack.Push(input[i]);
        }
        else 
        {
            stop = true;
        }
    }
    if (input[i] == ')')
    {
        if (stack.Count>0)
        {
            stack.Pop();
            current += 2;
            isStart = true;
        }
        else
        {
            stop = true;
        }
    }
   if (stop)
    {
        if (current > max)
        {
            max = current;
        }
        current = 0;
        stop = false;
    }
}
if (current > max)
{
    max = current;
}

Console.WriteLine(max);

