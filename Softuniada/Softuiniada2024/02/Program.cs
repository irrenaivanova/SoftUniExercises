int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n/2; i++)
{
    Console.Write(new string('.',n+i));
    Console.Write(new string('#', 3*n-2*i));
    Console.Write(new string('.', n + i));
    Console.WriteLine();
}

for (int i = n/2; i < n+1; i++)
{
    Console.Write(new string('.', n + i));
    Console.Write("#");
    Console.Write(new string('.', 3 * n - 2 * i-2));
    Console.Write("#");
    Console.Write(new string('.', n + i));
    Console.WriteLine();
}

Console.Write(new string('.', n *2));
Console.Write(new string('#', n));
Console.Write(new string('.', n *2));
Console.WriteLine();

for (int i = 0; i < n/2; i++)
{
    Console.Write(new string('.', n * 2-2));
    Console.Write(new string('#', n+4));
    Console.Write(new string('.', n * 2-2));
    Console.WriteLine();
}

Console.Write(new string('.', n*5/2-5));
Console.Write("D^A^N^C^E^");
Console.Write(new string('.', n * 5 / 2 - 5));
Console.WriteLine();

for (int i = 0; i < n / 2+1; i++)
{
    Console.Write(new string('.', n * 2 - 2));
    Console.Write(new string('#', n + 4));
    Console.Write(new string('.', n * 2 - 2));
    Console.WriteLine();
}