int n = int.Parse(Console.ReadLine());

Console.WriteLine(FibIterative(n));
Console.WriteLine(Fibonachi(n));
int FibIterative(int n)
{
    if (n ==1 || n==2)
    {
        return 1;
    }
    int result = 0;
    int minus1 = 1;
    int minus2 = 1;
    
    for (int i = 3; i <= n; i++)
    {
        result = minus1 + minus2;
        minus2 = minus1;
        minus1 = result;
    }
    return result;
}

int Fibonachi(int n)
{
    if (n == 1 ||  n == 2)
    {
        return 1;
    }

    return Fibonachi(n - 1) + Fibonachi(n - 2);
}