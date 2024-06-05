int n = Math.Abs(int.Parse(Console.ReadLine()));
Console.WriteLine(GetMultipleOfEvenAndOdds(n));

int GetMultipleOfEvenAndOdds(int n)
{
    return CalculateDigitsSum(n, 0) * CalculateDigitsSum(n, 1);
}

int CalculateDigitsSum(int n, int isOdd)
{
    int sum = 0;
    while (n != 0)
    {
        int lastDigit = n % 10;
        if (lastDigit % 2 == isOdd)
            sum += lastDigit;
        n /= 10;
    }
    return sum;
}