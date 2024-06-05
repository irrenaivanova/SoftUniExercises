double x1 = double.Parse(Console.ReadLine());
double y1 = double.Parse(Console.ReadLine());
double x2 = double.Parse(Console.ReadLine());
double y2 = double.Parse(Console.ReadLine());
double x3 = double.Parse(Console.ReadLine());
double y3 = double.Parse(Console.ReadLine());
double x4 = double.Parse(Console.ReadLine());
double y4 = double.Parse(Console.ReadLine());

double d1 = x1 - x2;
double d2 = y1 - y2;
double е1 = x3 - x4;
double е2 = y3 - y4;

if (TheLongest(d1, d2, е1, е2) == 1)
{
    TheCLosest(x1, y1, x2, y2);
}
else
{
    TheCLosest(x3, y3, x4, y4);
}


int TheLongest(double x1, double y1, double x2, double y2)
{
    int result = 0;
    double dist1 = Math.Sqrt(x1 * x1 + y1 * y1);
    double dist2 = Math.Sqrt(x2 * x2 + y2 * y2);

    if (dist1 >= dist2)
        result = 1;
    else
        result = 2;
    return result;
}

void TheCLosest(double x1, double y1, double x2, double y2)
{
    double dist1 = Math.Sqrt(x1 * x1 + y1 * y1);
    double dist2 = Math.Sqrt(x2 * x2 + y2 * y2);

    if (dist1 <= dist2)
        Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
    else
        Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
}