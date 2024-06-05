using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.Raiding.Engine.Interfaces;
using _03.Raiding.Factory.Interfaces;
using _03.Raiding.IO.Interfaces;
using _03.Raiding.Models;
using _03.Raiding.Models.Interfaces;

namespace _03.Raiding.Engine
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IFactory factory;
        private readonly ICollection<IBaseHero> heros;

        public Engine(IWriter writer, IReader reader, IFactory factory)
        {
            this.writer = writer;
            this.reader = reader;
            this.factory = factory;
            this.heros = new List<IBaseHero>();
        }

        public void Run()
        {
            int n = int.Parse(reader.Read());
            while (n>0)
            {
                string name = reader.Read();
                string type = reader.Read();

                try
                {
                    heros.Add(factory.Create(type, name));
                    n--;
                }
                catch (Exception ex)
                {
                    writer.Write(ex.Message);
                }

            }

            foreach (var hero in heros)
            {
                writer.Write(hero.CastAbility());
            }
            int power = int.Parse(reader.Read());
            int totalPower = heros.Sum(x => x.Power);

            if (totalPower >= power) writer.Write("Victory!");
            else writer.Write("Defeat...");
        }
    }
}
