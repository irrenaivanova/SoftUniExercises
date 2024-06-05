using System.Text.RegularExpressions;

string input = Console.ReadLine();
Regex regex = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+");
MatchCollection matches = regex.Matches(input);

Console.WriteLine(string.Join(" ", matches));