int n = int.Parse(Console.ReadLine());
int days = 0;
int total = 0;

while (n >= 100)
{
    total += n - 26;
    days++;
    n -= 10;
}
if (total >= 26)
    total -= 26;

Console.WriteLine(days);
Console.WriteLine(total);