int n = int.Parse(Console.ReadLine());
int divider = 0;

for (int i = 2; i <= 10; i++)
{
    if (n % i == 0 && i != 4 && i != 5 && i != 8 && i != 9)
        divider = i;
}
if (divider == 0)
    Console.WriteLine("Not divisible");
else
    Console.WriteLine($"The number is divisible by {divider}");