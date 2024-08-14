using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Equipment = new HashSet<IEquipment>();
            Athletes = new HashSet<IAthlete>(); 
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidGymName);
                }

                name = value; 
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => Equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment { get; private set; }

        public ICollection<IAthlete> Athletes { get; private set; }

        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count==Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment) => Equipment.Add(equipment);

        public void Exercise()=>Athletes.ToList().ForEach(x=>x.Exercise());  
  

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} is a {GetType().Name}:");
            if (!Athletes.Any())
            {
                sb.AppendLine("Athletes: No athletes");
            }
            else
            {
                sb.AppendLine($"Athletes: {string.Join(", ",Athletes.Select(x=>x.FullName))}");
            }
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().Trim();
        }

        public bool RemoveAthlete(IAthlete athlete) => Athletes.Remove(athlete);
   
    }
}
