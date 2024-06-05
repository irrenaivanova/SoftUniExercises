using System.Text;
using System.Text.RegularExpressions;

string[] inputPlayers = Console.ReadLine().Split(", ");
Dictionary<string, int> players = new Dictionary<string, int>();
foreach (string player in inputPlayers)
{
    players.Add(player, 0);
}

string patternLetters = @"[A-Za-z]";
string patternDistance = @"[0-9]";

while (true)
{
    string input = Console.ReadLine();
    if (input == "end of race")
        break;

    StringBuilder name = new StringBuilder();

    MatchCollection matchName = Regex.Matches(input, patternLetters);
    MatchCollection matchDistance = Regex.Matches(input, patternDistance);
    int distance = 0;
    foreach (Match match in matchName)
    {
        name.Append(match);
    }
    foreach (Match match in matchDistance)
    {
        distance += int.Parse(match.Value);
    }

    if (players.ContainsKey(name.ToString()))
    {
        players[name.ToString()] += distance;
    }
}
players = players.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
int count = 0;
foreach (var player in players)
{
    count++;
    if (count == 1)
        Console.WriteLine($"1st place: {player.Key}");
    if (count == 2)
        Console.WriteLine($"2nd place: {player.Key}");
    if (count == 3)
        Console.WriteLine($"3rd place: {player.Key}");
}

