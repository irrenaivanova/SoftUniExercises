int n = int.Parse(Console.ReadLine()!);

Console.Write(new string('.',n/2));
Console.Write(new string('#', n));
Console.Write(new string('.', n / 2));

Console.WriteLine();

for (int i = 0; i < n/2+1; i++)
{
    Console.Write(new string('.', n / 2));
    Console.Write('#');
    Console.Write(new string('.', n-2));
    Console.Write('#');
    Console.Write(new string('.', n / 2));
    Console.WriteLine();
}

Console.Write(new string('#', n / 2+1));
Console.Write(new string('.', n-2));
Console.Write(new string('#', n / 2+1));
Console.WriteLine();

for (int i = 1; i < n - 1; i++)
{
    Console.Write(new string('.',i));
    Console.Write('#');
    Console.Write(new string('.', 2*n-1-2*i-2));
    Console.Write('#');
    Console.Write(new string('.',i));
    Console.WriteLine();
}

Console.Write(new string('.', n-1));
Console.Write('#');
Console.Write(new string('.', n-1));