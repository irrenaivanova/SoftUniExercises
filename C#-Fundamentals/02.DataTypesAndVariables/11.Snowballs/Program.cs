using System.Numerics;

int N = int.Parse(Console.ReadLine());
BigInteger maXsnowballValue = 0;
int maXsnowballSnow = 0;
int maXsnowballTime = 0;
int maXsnowballQuality = 0;

for (int i = 1; i <= N; i++)
{
    int snowballSnow = int.Parse(Console.ReadLine());
    int snowballTime = int.Parse(Console.ReadLine());
    int snowballQuality = int.Parse(Console.ReadLine());

    BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
    if (snowballValue > maXsnowballValue && snowballTime != 0)
    {
        maXsnowballValue = snowballValue;
        maXsnowballQuality = snowballQuality;
        maXsnowballSnow = snowballSnow;
        maXsnowballTime = snowballTime;
    }
}
Console.WriteLine($"{maXsnowballSnow} : {maXsnowballTime} = {maXsnowballValue} ({maXsnowballQuality})");