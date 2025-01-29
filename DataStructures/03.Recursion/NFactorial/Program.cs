
int n = int.Parse(Console.ReadLine());

long factoriel = CalCFactoriel(n);
Console.WriteLine(factoriel);

long CalCFactoriel(int n)
{
    if (n == 0)
    {
        return 1;
    }

    return n * CalCFactoriel(n - 1);
}