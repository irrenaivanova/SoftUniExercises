using _007.MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _007.MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Id {  get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
        public override string ToString() 
            => $"Name: {FirstName} {LastName} Id: {Id}";
        
    }
}
