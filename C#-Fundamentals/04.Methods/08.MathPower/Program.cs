double result = MathPower(double.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));

double MathPower(double number, int power)
{
    return Math.Pow(number, power);
}
Console.WriteLine(result);