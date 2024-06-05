string input = Console.ReadLine();
int n = input.Length;
if (n % 2 == 1)
{
    Console.WriteLine(input[n / 2]);
}
else
    Console.WriteLine($"{input[n / 2 - 1]}{input[n / 2]}");