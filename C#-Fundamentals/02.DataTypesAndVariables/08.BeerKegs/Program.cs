int n = int.Parse(Console.ReadLine());
double maxVolume = 0;
string maxKeg = string.Empty;

for (int i = 1; i <= n; i++)
{
    string keg = Console.ReadLine();
    float radius = float.Parse(Console.ReadLine());
    int height = int.Parse(Console.ReadLine());

    double volume = Math.PI * radius * radius * height;
    if (volume > maxVolume)
    {
        maxVolume = volume;
        maxKeg = keg;
    }
}
Console.WriteLine(maxKeg);