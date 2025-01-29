
int n = int.Parse(Console.ReadLine());

Console.WriteLine(Fibonachi(n));

int prev1 = 0;
int prev2 = 1;
int current = 0;

for (int i = 2; i <= n; i++)
{
    current = prev1 + prev2;
    prev1 = prev2;
    prev2 = current;  
}

Console.WriteLine(current);
int Fibonachi(int n)
{
    if (n == 0)
    {
        return 0;
    }

    if (n == 1)
    {
        return 1;
    }

    return Fibonachi(n - 1) + Fibonachi(n - 2);
}