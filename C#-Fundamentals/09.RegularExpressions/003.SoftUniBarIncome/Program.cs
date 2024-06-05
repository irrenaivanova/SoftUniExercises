using System.Text.RegularExpressions;

double sum = 0;

while (true)
{
    string input = Console.ReadLine();
    if (input == "end of shift")
        break;

    string pattern = @"^%([A-Z][a-z]+)%[^|$%.]*<(\w+)>[^|$%.]*\|(\d+)\|[^|$%.]*?([-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";
    Match match = Regex.Match(input, pattern);
    if (match.Success)
    {
        string customer = match.Groups[1].Value;
        string product = match.Groups[2].Value;
        double totalPrice = double.Parse(match.Groups[4].Value) * int.Parse(match.Groups[3].Value);
        Console.WriteLine($"{customer}: {product} - {totalPrice:f2}");
        sum += totalPrice;
    }
}
Console.WriteLine($"Total income: {sum:f2}");