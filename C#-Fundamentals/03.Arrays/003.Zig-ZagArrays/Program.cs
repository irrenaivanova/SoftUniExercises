int n = int.Parse(Console.ReadLine());
string new1 = String.Empty;
string new2 = String.Empty;

for (int i = 1; i <= n; i++)
{
    int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

    if (i % 2 != 0)
    {
        new1 += array[0] + " ";
        new2 += array[1] + " ";
    }
    else
    {
        new1 += array[1] + " ";
        new2 += array[0] + " ";
    }
}
Console.WriteLine(new1);
Console.WriteLine(new2);