int n = int.Parse(Console.ReadLine());
double sum = 0;

for (int i = 1; i <= n; i++)
{
    double price = double.Parse(Console.ReadLine());
    int days = int.Parse(Console.ReadLine());
    int caps = int.Parse(Console.ReadLine());
    Console.WriteLine($"The price for the coffee is: ${price * days * caps:f2}");
    sum += price * days * caps;
}
Console.WriteLine($"Total: ${sum:f2}");