RecursiveFor(5, 0);

void RecursiveFor(int times, int level)
{
    if (times==0)
    {
        return;
    }
    Console.Write(new string(' ',level*3));
    Console.WriteLine($"{times}. Before recursion");
    RecursiveFor(times - 1, level + 1);

    Console.Write(new string(' ', level * 3));
    Console.WriteLine($"{times}. After recursion");
}