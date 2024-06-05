using System.Text.RegularExpressions;

string input = Console.ReadLine();
Regex regex = new Regex(@"\+359(-| )2\1[0-9]{3}\1[0-9]{4}\b");

MatchCollection matches = regex.Matches(input);

Console.WriteLine(string.Join(", ", matches));
