int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    Console.Write(new string(' ',n-1-i));
	for (int j = 0; j < i+1; j++)
	{
        Console.Write("* ");
    }
    Console.WriteLine();
}
//TODO
for (int i = n-2; i >= 0; i--)s
{
    Console.Write(new string(' ', n - 1 - i));
    for (int j = 0; j < i + 1; j++)
    {
        Console.Write("* ");
    }
    Console.WriteLine();
}
