using P03.Detail_Printer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.Detail_Printer.Models
{
    public class DetailsPrinter: IPrinter
    {
        public DetailsPrinter(IReadOnlyList<IEmployee> employees)
        {
            Employees = employees;
        }

        public IReadOnlyList<IEmployee> Employees { get; private set; }

        public string Print()
        {
            return string.Join('\n',Employees.Select(x=>x.ToString())); 
        }
    }
}
