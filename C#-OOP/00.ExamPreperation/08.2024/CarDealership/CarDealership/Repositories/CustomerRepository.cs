using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repositories
{
    public class CustomerRepository : IRepository<ICustomer>
    {
        private readonly List<ICustomer> models;

        public CustomerRepository()
        {
            models = new List<ICustomer>();
            Models = models.AsReadOnly();
        }

        public IReadOnlyCollection<ICustomer> Models {get;}

        public void Add(ICustomer model)
        {
            models.Add(model);
        }

        public bool Exists(string text)
        {
            var veh = models.FirstOrDefault(x => x.Name == text);
            if (veh is null) return false;
            return true;
        }

        public ICustomer Get(string text)
        {
            return models.FirstOrDefault(x => x.Name == text);
        }

        public bool Remove(string text)
        {
            return models.Remove(models.FirstOrDefault(x => x.Name == text));
        }
    }
}
