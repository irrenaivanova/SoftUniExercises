using _04.Team;
using PersonsInfo;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        
        Team team = new Team("SoftUni");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            try
            {
                team.AddPlayer(new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3])));
                              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
    }
}
