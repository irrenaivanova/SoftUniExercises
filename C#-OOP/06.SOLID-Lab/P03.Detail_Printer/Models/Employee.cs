using P03.Detail_Printer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer.Models
{
    public class Employee : IEmployee

    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public override string ToString() => Name;
      
    }
}
