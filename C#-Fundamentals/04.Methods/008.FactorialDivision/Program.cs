int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());

Console.WriteLine($"{(1.0 * Faktoriel(a) / Faktoriel(b)):f2}");

long Faktoriel(int n)
{
    long product = 1;
    for (int i = 1; i <= n; i++)
    {
        product *= i;
    }
    return product;
}