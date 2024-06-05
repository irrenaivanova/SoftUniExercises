string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
double sum = 0;

for (int i = 0; i < input.Length; i++)
{
    int firstLetter = (int)(input[i][0]);
    int lastLetter = (int)(input[i][input[i].Length - 1]);
    double substring = int.Parse(input[i].Substring(1, input[i].Length - 2));
    if (firstLetter >= 65 && firstLetter <= 90)
    {
        substring /= Math.Round((1.0 * (firstLetter - 64)), 2);
    }
    else
    {
        substring *= Math.Round((1.0 * (firstLetter - 96)), 2);
    }
    if (lastLetter >= 65 && lastLetter <= 90)
    {
        substring -= (lastLetter - 64);
    }
    else
    {
        substring += (lastLetter - 96);
    }
    sum += substring;
}
Console.WriteLine($"{sum:f2}");