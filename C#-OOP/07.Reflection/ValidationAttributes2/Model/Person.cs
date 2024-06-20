using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes2.Attributes;

namespace ValidationAttributes2.Model
{
    public class Person
    {
        private const int MinAge = 12;
        private const int MaxAge = 90;
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }
        [MaxRequired]
        public string FullName { get; private set; }
        
        [MyRange(MinAge,MaxAge)]
        public int Age { get; private set; }
    }
}
