using _007.MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, IReadOnlyCollection<Private> privates)
            : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates { get; private set; }
        public override string ToString() => $"{base.ToString()}{Environment.NewLine}" +
            $"Privates:{Environment.NewLine}  {string.Join("\n  ", Privates)}";
       
    }
}
