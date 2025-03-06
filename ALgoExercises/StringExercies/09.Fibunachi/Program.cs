int n = int.Parse(Console.ReadLine());
int[] result = new int[n+1];

if (n > 2)
{
    result[0] = 0;
    result[1] = 1;
    result[2] = 1;
}

for (int i = 3; i <= n; i++)
{
    result[i] = result[i - 1] + result[i - 2];
}

if (n == 0)
{
    Console.WriteLine(0);
}
else if (n == 1 || n == 2)
{
    Console.WriteLine(result[n]);
}
else
{
    Console.WriteLine(result[n]);
}
