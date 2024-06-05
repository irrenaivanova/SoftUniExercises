int N = int.Parse(Console.ReadLine());
int M = int.Parse(Console.ReadLine());
int Y = int.Parse(Console.ReadLine());
int n = N;
int targets = 0;

while (n >= M)
{
    n -= M;
    targets++;
    if (n * 1.0 / N == 0.5 && Y > 0)
        n /= Y;
}
Console.WriteLine(n);
Console.WriteLine(targets);