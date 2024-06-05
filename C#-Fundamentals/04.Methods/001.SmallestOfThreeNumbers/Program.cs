int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());

Console.WriteLine(SmallestOfThreeNum(a, b, c));

int SmallestOfThreeNum(int a, int b, int c)
{
    return Math.Min(a, Math.Min(b, c));
}