﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int powerConst = 100;
        public Warrior(string name) : base(name, powerConst)
        {
        }
        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {powerConst} damage";
        }
    }
}
