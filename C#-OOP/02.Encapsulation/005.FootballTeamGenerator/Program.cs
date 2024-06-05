
using _005.FootballTeamGenerator;
using System.Runtime.ExceptionServices;

List<Team> teams = new List<Team>();
while (true)
{
    string[] input = Console.ReadLine().Split(";");
    if (input[0] == "END")
        break;
    try
    {
        if (input[0] == "Team")
        {
            Team team = new Team(input[1]);
            teams.Add(team);
        }
        if (input[0] == "Add")
        {
            if (teams.FirstOrDefault(x => x.Name == input[1]) == null)
            {
                Console.WriteLine($"Team {input[1]} does not exist.");
            }
            else
            {
                teams.First(x => x.Name == input[1])
                    .AddPlayer(new Player(input[2], int.Parse(input[3]),
                    int.Parse(input[4]), int.Parse(input[5]),
                    int.Parse(input[6]), int.Parse(input[7])));
            }
        }
        if (input[0] == "Remove")
        {
            if (teams.FirstOrDefault(x => x.Name == input[1]) == null)
            {
                Console.WriteLine($"Team {input[1]} does not exist.");
            }
            teams.First(x => x.Name == input[1]).RemovePlayer(input[2]);
        }
        if (input[0] == "Rating")
        {
            if (teams.FirstOrDefault(x => x.Name == input[1]) == null)
            {
                Console.WriteLine($"Team {input[1]} does not exist.");
            }
            else
            {
                Console.WriteLine(teams.First(x => x.Name == input[1]));
            }
        }
    }

    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


