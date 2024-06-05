int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());

int min = Math.Min(a, Math.Min(b, c));
int max = Math.Max(a, Math.Max(b, c));
int middle = a + b + c - min - max;

Console.WriteLine(max);
Console.WriteLine(middle);
Console.WriteLine(min);