int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());

for (int i = a; i <= b; i++)
{
    Console.Write($"{Convert.ToChar(i)} ");
}