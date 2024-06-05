using System.Text.RegularExpressions;

string input = Console.ReadLine();
string pattern = @"([=/])([A-Z][A-Za-z]{2,})(\1)";

MatchCollection matches = Regex.Matches(input, pattern);
List<string> destinations = new List<string>();

foreach (Match match in matches)
{
    destinations.Add(match.Groups[2].Value);
}
Console.WriteLine($"Destinations: {string.Join(", ",destinations)}");
Console.WriteLine($"Travel Points: {destinations.Sum(x=>x.Length)}");