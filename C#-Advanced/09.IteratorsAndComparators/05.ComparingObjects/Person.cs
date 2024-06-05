using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }
        public string Name { get; set; }
        public int Age { get; private set; }
        public string Town { get; private set; }

        public int CompareTo(Person other)
        {
            if (Name.CompareTo(other.Name) == 0)
            {
                if (Age.CompareTo(other.Age) == 0)
                {
                    if (Town.CompareTo(other.Town) == 0)
                    {
                        return 0;
                    }
                }
            }
            return 1;
        }
    }
    public class StudentComparer :IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Name.CompareTo(y.Name) == 0)
            {
                if (x.Age.CompareTo(y.Age) == 0)
                {
                    if (x.Town.CompareTo(y.Town) == 0)
                    {
                        return 0;
                    }
                }
            }
            return 1;
        }
    }

}
