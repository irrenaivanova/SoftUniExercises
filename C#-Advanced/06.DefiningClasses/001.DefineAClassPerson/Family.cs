using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people  = new List<Person>();

        public void AddMembers(Person person)
        {
            people.Add(person);
        }
        public Person GetOldestMember()
        {
            return people.OrderByDescending(x => x.Age).First();
        }

        public List<Person> GetMembers() 
        { 
            return people.Where(x=>x.Age>30).OrderBy(x=>x.Name).ToList();
        }
    }
}
