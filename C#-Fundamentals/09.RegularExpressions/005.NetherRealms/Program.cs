using System.Text.RegularExpressions;
Regex splitPattern = new Regex("\\s*,+\\s*");
string[] input = splitPattern.Split(Console.ReadLine());
SortedDictionary<string, double[]> deamons = new SortedDictionary<string, double[]>();

for (int i = 0; i < input.Length; i++)
{
    string name = input[i];
    string patternHealth = @"[^+\-*/.\d]";
    string patternDigits = @"((|-)\d+\.\d+|(|-)\d+)";
    int health = 0;
    double damage = 0;

    MatchCollection matchesHealth = Regex.Matches(name, patternHealth);
    MatchCollection matchesDigits = Regex.Matches(name, patternDigits);
    MatchCollection matchesMultiply = Regex.Matches(name, "\\*");
    MatchCollection matchesDiv = Regex.Matches(name, "\\/");

    foreach (Match match in matchesDigits)
    {
        double currNumber = double.Parse(match.Value);
        damage += currNumber;
    }
    for (int j = 0; j < matchesMultiply.Count; j++)
    {
        damage *= 2;
    }
    for (int j = 0; j < matchesDiv.Count; j++)
    {
        damage /= 2;
    }
    foreach (Match match in matchesHealth)
    {
        char[] sign = match.Value.ToCharArray();
        for (int j = 0; j < sign.Length; j++)
        {
            health += (int)(sign[j]);
        }
    }
    if (!deamons.ContainsKey(name))
    {
        deamons.Add(name, new double[2]);
        deamons[name][0] = health;
        deamons[name][1] = damage;
    }
}
foreach (var item in deamons)
{
    Console.WriteLine($"{item.Key} - {item.Value[0]} health, {item.Value[1]:f2} damage");
}
