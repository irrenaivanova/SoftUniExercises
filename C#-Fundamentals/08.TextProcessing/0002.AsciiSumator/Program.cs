char start = char.Parse(Console.ReadLine());
char end = char.Parse(Console.ReadLine());
string input = Console.ReadLine();
int sum = 0;

foreach (var item in input)
{
    if (item > start && item < end)
    {
        sum += item;
    }
}
Console.WriteLine(sum);