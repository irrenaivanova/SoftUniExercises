double x1 = double.Parse(Console.ReadLine());
double y1 = double.Parse(Console.ReadLine());
double x2 = double.Parse(Console.ReadLine());
double y2 = double.Parse(Console.ReadLine());

TheCLosest(x1, y1, x2, y2);

void TheCLosest(double x1, double y1, double x2, double y2)
{
    double dist1 = Math.Sqrt(x1 * x1 + y1 * y1);
    double dist2 = Math.Sqrt(x2 * x2 + y2 * y2);

    if (dist1 <= dist2)
        Console.WriteLine($"({x1}, {y1})");
    else
        Console.WriteLine($"({x2}, {y2})");
}