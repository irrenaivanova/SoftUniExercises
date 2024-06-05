
using _005.BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005.BirthdayCelebrations.Models
{
    public class Citizens : IIdentifiable,IBirthdable,INameable
    {
        public Citizens(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }

        public string Birthday { get; private set; }

        public override string ToString()
        {
            return Id;
        }
    }
}
