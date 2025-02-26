int n = int.Parse(Console.ReadLine()!);

for (int i = 1; i <= n; i++)
{
    for (int j = 1; j <= i; j++)
    {
        if (j<10)
        {
            Console.Write($"{j}  ");
            continue;
        }
        Console.Write($"{j} ");
    }
    Console.WriteLine();
}
