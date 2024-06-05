PrintTriangle(int.Parse(Console.ReadLine()));

void PrintTriangle(int n)
{
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= i; j++)
        {
            Console.Write($"{j} ");
        }
        Console.WriteLine();
    }

    for (int i = n - 1; i > 0; i--)
    {
        for (int j = 1; j <= i; j++)
        {
            Console.Write($"{j} ");
        }
        Console.WriteLine();
    }
}