using System;
using System.Text.RegularExpressions;

string input = Console.ReadLine();
Regex regex = new Regex(@"([0-9]{2})([\/\-\.])([A-Z][a-z]{2})\2([0-9]{4})");

MatchCollection matches = regex.Matches(input);

foreach (Match match in matches)
{
    Console.WriteLine($"Day: {match.Groups[1]}, " +
        $"Month: {match.Groups[3].Value}, " +
        $"Year: {match.Groups[4].Value}");
}
