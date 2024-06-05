using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = 0;
            Pokemons = new();
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }
        public void IsThereELement(string element)
        {
            if(Pokemons.Any(x=>x.Element == element))
            {
                NumberOfBadges++;
            }
            else
            {
                Pokemons.ForEach(x =>  x.Health -= 10);
                Pokemons = Pokemons.Where(x=> x.Health>0).ToList();
            }
        }
    }
}
