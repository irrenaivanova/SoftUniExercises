int n = int.Parse(Console.ReadLine());
List<Team> teams = new List<Team>();

for (int i = 0; i < n; i++)
{
    string[] teamInfo = Console.ReadLine().Split("-");
    string leader = teamInfo[0];
    string teamName = teamInfo[1];
    bool ifTeamExist = false;
    bool ifLeaderExist = false;

    foreach (var team in teams)
    {
        if (team.Leader == leader)
        {
            Console.WriteLine($"{leader} cannot create another team!");
            ifLeaderExist = true;
            break;
        }
        if (team.TeamName == teamName)
        {
            Console.WriteLine($"Team {teamName} was already created!");
            ifTeamExist = true;
            break;
        }
    }

    if (!ifTeamExist && !ifLeaderExist)
    {
        Team team = new Team(teamName, leader);
        teams.Add(team);
        Console.WriteLine($"Team {teamName} has been created by {leader}!");
    }
}


while (true)
{
    string command = Console.ReadLine();
    if (command == "end of assignment")
        break;

    string[] infoMembers = command.Split("->");
    string teamName = infoMembers[1];
    string member = infoMembers[0];

    Team currTeam = teams.FirstOrDefault(x => x.TeamName == teamName);
    if (currTeam is null)
    {
        Console.WriteLine($"Team {teamName} does not exist!");
        continue;
    }

    if (teams.SelectMany(x => x.Members).Contains(member) || teams.Select(x => x.Leader).Contains(member))
    {
        Console.WriteLine($"Member {member} cannot join team {teamName}!");
        continue;
    }

    currTeam.Members.Add(member);

}



teams = teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName).ToList();

foreach (Team team in teams)
{
    if (team.Members.Count > 0)
        Console.WriteLine(team);
}
Console.WriteLine("Teams to disband:");
foreach (Team team in teams)
{
    if (team.Members.Count == 0)
        Console.WriteLine(team.TeamName);
}

class Team
{
    public Team(string teamName, string leader)
    {
        TeamName = teamName;
        Leader = leader;
    }
    public string TeamName { get; set; }
    public string Leader { get; set; }
    public List<string> Members { get; set; } = new List<string>();

    public override string ToString()
    {
        Members.Sort();
        return $"{TeamName}\n " +
               $"- {Leader} \n" +
               $"-- {string.Join("\n-- ", Members)}";
    }
}
