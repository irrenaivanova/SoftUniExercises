int n = int.Parse(Console.ReadLine());
int total = 0;

for (int i = 1; i <= n; i++)
{
    int input = int.Parse(Console.ReadLine());
    total += input;
    if (total > 255)
    {
        Console.WriteLine("Insufficient capacity!");
        total -= input;
    }
}
Console.WriteLine(total);