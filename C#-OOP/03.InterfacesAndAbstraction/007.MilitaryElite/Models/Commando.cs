﻿using _007.MilitaryElite.Enums;
using _007.MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _007.MilitaryElite.Models
{
    internal class Commando : SpecialedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps,IReadOnlyCollection<IMission> missions) 
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = missions;
        }

        public IReadOnlyCollection<IMission> Missions { get; private set; }
        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
