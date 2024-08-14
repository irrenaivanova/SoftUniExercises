using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public abstract class Customer : ICustomer
    {
        private readonly List<string> purchases;

        protected Customer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ExceptionMessages.NameIsRequired);
            Name = name;
            purchases = new List<string>();
            Purchases = purchases.AsReadOnly();
        }

        public string Name { get; }

        public IReadOnlyCollection<string> Purchases { get;}

        public override string ToString() => $"{Name} - Purchases: {Purchases.Count}";


        public virtual void BuyVehicle(string vehicleModel)
        {
            purchases.Add(vehicleModel);
        }
    }
}
