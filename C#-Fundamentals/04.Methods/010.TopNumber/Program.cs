int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    int number = i;
    int sum = 0;
    bool isOneNumberOdd = false;
    while (number != 0)
    {
        int lastDigit = number % 10;
        sum += lastDigit;
        number /= 10;
        if (lastDigit % 2 == 1)
            isOneNumberOdd = true;
    }
    if (isOneNumberOdd && sum % 8 == 0)
        Console.WriteLine(i);
}