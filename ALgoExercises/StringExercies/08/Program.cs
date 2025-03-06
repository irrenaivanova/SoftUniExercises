string[] input = Console.ReadLine()!.Split(" ",StringSplitOptions.RemoveEmptyEntries);
double sum = 0;
foreach (var item in input)
{
    char firstLetter = item[0];
    char lastLetter = item[item.Length - 1];
    double number = int.Parse(item.Substring(1, item.Length - 2));

    if (char.IsUpper(firstLetter))
    {
        int placeAlphabet = firstLetter - 'A' + 1;
        number /= placeAlphabet;
    }

    if (char.IsLower(firstLetter))
    {
        int placeAlphabet = firstLetter - 'a' + 1;
        number *= placeAlphabet;
    }

    if (char.IsUpper(lastLetter))
    {
        int placeAlphabet = lastLetter - 'A' + 1;
        number -= placeAlphabet;
    }

    if (char.IsLower(lastLetter))
    {
        int placeAlphabet = lastLetter - 'a' + 1;
        number += placeAlphabet;
    }

    sum += number;
}
Console.WriteLine($"{sum:F2}");