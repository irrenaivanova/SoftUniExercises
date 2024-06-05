
using _005.BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005.BirthdayCelebrations.Models
{
    public class Robot : IIdentifiable, INameable
    {
        public Robot(string name, string id,string birthday)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; private set; }
        public string Id { get; private set; }

        public override string ToString()
        {
            return Id;
        }
    }
}
