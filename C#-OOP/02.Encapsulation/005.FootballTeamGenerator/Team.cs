using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _005.FootballTeamGenerator
{

    public class Team
    {
        private string name;
        private readonly List<Player> players;
        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
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
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string name)
        {
            if (players.FirstOrDefault(p => p.Name == name) == null)
            {
                throw new ArgumentException($"Player {name} is not in {Name} team.");
            }

            players.Remove(players.First(x => x.Name == name));
        }

        public double Stats
        {
            get
            {
                if (players.Any())
                {
                    return players.Average(p => p.Stats);
                }

                return 0;
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Stats:f0}";
        }
    }
}
