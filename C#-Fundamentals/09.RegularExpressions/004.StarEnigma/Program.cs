using System.Text;
using System.Text.RegularExpressions;

int n = int.Parse(Console.ReadLine());
List<string> attaced = new List<string>();
List<string> destroyed = new List<string>();

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    string patternLetter = "[sStTaArR]";
    MatchCollection matchesletter = Regex.Matches(input, patternLetter);
    int number = matchesletter.Count;

    StringBuilder decrypted = new StringBuilder();
    foreach (char symbol in input)
    {
        decrypted.Append((char)((int)symbol - number));
    }

    string patternsoldier = @"@([A-Za-z]+)[^@\-!:>]*:[0-9]+[^@\-!:>]*!([AD])![^@\-!:>]*?->[0-9]+";

    Match match = Regex.Match(decrypted.ToString(), patternsoldier);
    if (match.Success)
    {
        string planet = match.Groups[1].Value;
        string type = match.Groups[2].Value;
        if (type == "A")
        {
            attaced.Add(planet);
        }
        else if (type == "D")
        {
            destroyed.Add(planet);
        }
    }
}

Console.WriteLine($"Attacked planets: {attaced.Count}");
foreach (var item in attaced.OrderBy(x => x))
{
    Console.WriteLine($"-> {item}");
}
Console.WriteLine($"Destroyed planets: {destroyed.Count}");
foreach (var item in destroyed.OrderBy(x => x))
{
    Console.WriteLine($"-> {item}");
}