int n = int.Parse(Console.ReadLine());

Print(n);

void Print(int n)
{
    if (n == 0)
    {
        return;
    }
    Console.WriteLine($"Dimitrichko e top" + n);
    Print(n - 1);
}