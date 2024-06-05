int input = int.Parse(Console.ReadLine());
int sum = 0;

int n = input;

while (n != 0)
{
    int lastDigit = n % 10;
    int faktorial = 1;
    for (int i = 1; i <= lastDigit; i++)
    {
        faktorial *= i;
    }
    sum += faktorial;
    n /= 10;
}
if (sum == input)
    Console.WriteLine("yes");
else
    Console.WriteLine("no");