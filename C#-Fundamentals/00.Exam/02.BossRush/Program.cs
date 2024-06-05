using System.Text.RegularExpressions;

int n = int.Parse(Console.ReadLine());
string pattern = @"\|([A-Z]{4,})\|:#([A-Za-z]+\s[A-Za-z]+)#";

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    Match match = Regex.Match(input, pattern);
    if (!match.Success)
    {
        Console.WriteLine("Access denied!");
    }
    else
    {
        Console.WriteLine($"{match.Groups[1].Value}, The {match.Groups[2].Value}");
        Console.WriteLine($">> Strength: {match.Groups[1].Value.Length}");
        Console.WriteLine($">> Armor: {match.Groups[2].Value.Length}");
    }
}
