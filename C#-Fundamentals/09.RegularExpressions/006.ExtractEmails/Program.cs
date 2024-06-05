using System.Text.RegularExpressions;

string input = Console.ReadLine();
string pattern = @"(?<=\s)([A-Za-z0-9]+[-_.]?[A-Za-z0-9]+)@([A-Za-z]+\-?[A-za-z]+)\.(([A-Za-z]+\-?[A-za-z]+)\.)*[a-zA-Z]+";

MatchCollection matches = Regex.Matches(input, pattern);

foreach (Match match in matches)
{
    Console.WriteLine(match);
}