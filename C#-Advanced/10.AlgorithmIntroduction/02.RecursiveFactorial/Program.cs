int n = int.Parse(Console.ReadLine());

Console.WriteLine(GetFactorial(n));

int GetFactorial(int n)
{
    if (n==1)
    {
        return 1;
    }
    return n * GetFactorial(n - 1);
}

