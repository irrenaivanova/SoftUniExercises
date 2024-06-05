using PersonsInfo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Team
{
    public class Team
    {
        public Team(string name)
        {
            Name = name;
        }
        private List<Person> firstTeam = new List<Person>();
        private List<Person> reserveTeam = new List<Person>();

        public IReadOnlyCollection<Person> FirstTeam
        {
            get { return firstTeam.AsReadOnly(); } 
        }
        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return reserveTeam.AsReadOnly(); }
        }
        public string Name { get; private set; }
       
        public void AddPlayer(Person person) 
        {
            if (person.Age<40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
    }
}
