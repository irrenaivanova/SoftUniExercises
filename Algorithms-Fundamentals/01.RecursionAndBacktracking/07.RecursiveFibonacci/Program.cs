using System;

int n = int.Parse(Console.ReadLine());
int fib = GetFibun(n);
Console.WriteLine(fib);

int GetFibun(int n)
{
    if (n <= 1)
        return 1;

    return GetFibun(n-1) + GetFibun(n - 2);
}


