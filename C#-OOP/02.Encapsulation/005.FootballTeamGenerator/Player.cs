using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005.FootballTeamGenerator;

public class Player
{
    private const int MinStats = 0;
    private const int MaxStats = 100;
    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }

  

    public int Endurance
    {
        get => endurance;
        private set
        {
            if (value<MinStats || value>MaxStats)
            {
                throw new ArgumentException(string.Format(ExceptionsMessage.StatsException,nameof(Endurance),MinStats,MaxStats));
            }
            endurance = value;
        }
    }
    public int Sprint
    {
        get => sprint;
        private set
        {
            if (value < MinStats || value > MaxStats)
            {
                throw new ArgumentException(string.Format(ExceptionsMessage.StatsException, nameof(Sprint), MinStats, MaxStats));
            }
            sprint = value;
        }
    }
    public int Dribble
    {
        get => dribble;
        private set
        {
            if (value < MinStats || value > MaxStats)
            {
                throw new ArgumentException(string.Format(ExceptionsMessage.StatsException, nameof(Dribble), MinStats, MaxStats));
            }
            dribble = value;
        }
    }
    public int Passing
    {
        get => passing;
        private set
        {
            if (value < MinStats || value > MaxStats)
            {
                throw new ArgumentException(string.Format(ExceptionsMessage.StatsException, nameof(Passing), MinStats, MaxStats));
            }
            passing = value;
        }
    }
    public int Shooting
    {
        get => shooting;
        private set
        {
            if (value < MinStats || value > MaxStats)
            {
                throw new ArgumentException(string.Format(ExceptionsMessage.StatsException, nameof(Shooting), MinStats, MaxStats));
            }
            shooting = value;
        }
    }

    public double Stats => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
}

