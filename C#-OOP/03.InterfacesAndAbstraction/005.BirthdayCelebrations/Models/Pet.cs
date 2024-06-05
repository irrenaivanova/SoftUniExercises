
using _005.BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005.BirthdayCelebrations.Models
{
    public class Pet : INameable, IBirthdable
    {
        public Pet(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public string Name { get; private set; }

        public string Birthday { get; private set; }
    }
}
