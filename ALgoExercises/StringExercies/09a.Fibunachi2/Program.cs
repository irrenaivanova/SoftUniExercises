int n = int.Parse(Console.ReadLine()!);

int prev1 = 1;
int prev2 = 1;
int current = 0;

for (int i = 3; i <=n; i++)
{
    current = prev1 + prev2;
    prev1 = prev2;
    prev2 = current;
}

if (n == 0)
{
    Console.WriteLine(0);
}
else if (n == 1 || n == 2)
{
    Console.WriteLine(1);
}
else
{
    Console.WriteLine(current);
}

