using System;

Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();

while (true)
{
    string command = Console.ReadLine();
    if (command == "Season end")
        break;
    if (command.Contains(">"))
    {
        string[] input = command.Split(" -> ");
        string player = input[0];
        string position = input[1];
        int skill = int.Parse(input[2]);

        if (!players.ContainsKey(player))
        {
            players.Add(player, new Dictionary<string, int>());
            players[player].Add(position, skill);
        }
        else
        {
            if (!players[player].ContainsKey(position))
            {
                players[player].Add(position, skill);
            }
            else if (players[player][position] < skill)
            {
                players[player][position] = skill;
            }
        }
    }
    else
    {
        string[] input = command.Split();
        string player1 = input[0];
        string player2 = input[2];

        if (players.ContainsKey(player1) && players.ContainsKey(player2))
        {
            bool ifSomethingInCommon = false;
            string demotedPlayer = string.Empty;
            bool isDemoted = false;

            List<string> player1skills = players[player1].Keys.ToList();
            List<string> player2skills = players[player2].Keys.ToList();

            for (int i = 0; i < player1skills.Count; i++)
            {
                for (int j = 0; j < player2skills.Count; j++)
                {
                    if (player1skills[i] == player2skills[j])
                    {
                        ifSomethingInCommon = true;
                        break;
                    }
                }
            }
            if (ifSomethingInCommon)
            {
                if (players[player1].Values.Sum() > players[player2].Values.Sum())
                {
                    demotedPlayer = player2;
                    isDemoted = true;
                }
                else if (players[player1].Values.Sum() < players[player2].Values.Sum())
                {
                    demotedPlayer = player1;
                    isDemoted = true;
                }
            }
            if (isDemoted)
            {
                players.Remove(demotedPlayer);
            }
        }
    }
}

foreach (var item in players.OrderByDescending(x => x.Value.Values.Sum()))
{
    Console.WriteLine($"{item.Key}: {item.Value.Values.Sum()} skill");
    foreach (var item1 in item.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
    {
        Console.WriteLine($"- {item1.Key} <::> {item1.Value}");
    }
}