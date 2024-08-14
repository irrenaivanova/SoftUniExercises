using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private readonly List<IVehicle> models;

        public VehicleRepository()
        {
            models = new List<IVehicle>();
            Models = models.AsReadOnly();
        }

        public IReadOnlyCollection<IVehicle> Models { get;}

        public void Add(IVehicle model)
        {
            models.Add(model);
        }

        public bool Exists(string text)
        {
            var veh = models.FirstOrDefault(x => x.Model == text);
            if (veh is null) return false;
                return true;
        }

        public IVehicle Get(string text)
        {
            return models.FirstOrDefault(x => x.Model == text);
        }

        public bool Remove(string text)
        {
            return models.Remove(models.FirstOrDefault(x=>x.Model==text));
        }
    }
}
