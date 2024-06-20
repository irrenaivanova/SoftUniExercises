using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _20._08._03.VetClinic
{ 
    public class Clinic
    {
        private  List<Pet> data;

        public Clinic(int capacity)
        {
            data = new List<Pet>();
            Capacity = capacity;
        }

        public int Capacity { get; private set; }

        public void Add(Pet pet)
        {
            if (data.Count < Capacity) 
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name) 
        {
            var pet = data.FirstOrDefault(x=>x.Name==name);
            if (pet != null) 
            {
                data.Remove(pet);
                return true;
            }
            return false;
        }

        public Pet GetPet(string name, string owner)
            => data.FirstOrDefault(x => x.Name == name && x.Owner == owner);

        public Pet GetOldestPet()
            => data.OrderByDescending(x=>x.Age).FirstOrDefault();


        public int Count => data.Count;

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString();
        }
    }
}
