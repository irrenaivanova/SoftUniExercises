using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._08._03.VetClinic
{
    public class Pet
    {
        public Pet(string name, int age, string owner)
        {
            Name = name;
            Age = age;
            Owner = owner;
        }

        public string Name { get; set; }
        public int Age{ get; set; }
        public string Owner { get; set; }
        public override string ToString()
        {
            return $"Name: {Name} Age: {Age} Owner: {Owner}";
        }
    }
}
