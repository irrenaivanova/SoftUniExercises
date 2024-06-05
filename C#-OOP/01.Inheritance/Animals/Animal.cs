using Animals;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal
    {
        private int age;
        private string gender;
        private string name;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        
        public int Age 
        {
            get { return age; } 
            private set
            {
                if (value > 0 )
                {
                    age = value;
                }
                else
                {
                    throw new InvalidOperationException("Invalid input!");
                }
            } 
        }
        public string Gender
        {
            get { return gender; }
            private set
            {
                if ((value == "Female" || value == "Male") && !string.IsNullOrWhiteSpace(value))
                {
                    gender = value;
                }
                else
                {
                    throw new InvalidOperationException("Invalid input!");
                }
            }
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
                else
                {
                    throw new InvalidOperationException("Invalid input!");
                }
            }
        }

        public virtual string ProduceSound()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine(base.ToString().Substring(base.ToString().IndexOf('.')+1));
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine(ProduceSound());
            return sb.ToString().TrimEnd();
        }
    }
}

