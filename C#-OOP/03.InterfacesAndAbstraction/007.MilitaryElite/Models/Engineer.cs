using _007.MilitaryElite.Enums;
using _007.MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007.MilitaryElite.Models
{
    public class Engineer : SpecialedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IRepair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs { get; private set; }

        public override string ToString() => $"{base.ToString()}{Environment.NewLine}" +
             $"Repairs:{Environment.NewLine}  {string.Join("\n  ", Repairs)}";
    }
}
