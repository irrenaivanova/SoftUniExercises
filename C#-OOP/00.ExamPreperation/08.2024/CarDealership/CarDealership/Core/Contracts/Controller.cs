using CarDealership.Models;
using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Core.Contracts
{
    public class Controller : IController
    {
        private readonly Dealership dealership = new();

        public string AddCustomer(string customerTypeName, string customerName)
        {
            ICustomer customer;
            if (customerTypeName == "IndividualClient")
                customer = new IndividualClient(customerName);
            else if (customerTypeName == "LegalEntityCustomer")
                customer = new LegalEntityCustomer(customerName);
            else
                return string.Format(OutputMessages.InvalidType, customerTypeName);

            if (dealership.Customers.Exists(customerName))
                return string.Format(OutputMessages.CustomerAlreadyAdded, customerName);

            dealership.Customers.Add(customer);
            return string.Format(OutputMessages.CustomerAddedSuccessfully, customerName);  
        }

        public string AddVehicle(string vehicleTypeName, string model, double price)
        {
            IVehicle vehicle;
            if (vehicleTypeName == "SaloonCar")
                vehicle = new SaloonCar(model, price);
            else if (vehicleTypeName == "SUV")
                vehicle = new SUV(model, price);
            else if (vehicleTypeName== "Truck")
                vehicle = new Truck(model, price);
            else
                return string.Format(OutputMessages.InvalidType, vehicleTypeName);

            if (dealership.Vehicles.Exists(model))
                return string.Format(OutputMessages.VehicleAlreadyAdded, model);

            dealership.Vehicles.Add(vehicle);
            return string.Format(OutputMessages.VehicleAddedSuccessfully, vehicleTypeName,model,vehicle.Price);
        }

        public string CustomerReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Customer Report:");
            foreach (var customer in dealership.Customers.Models.OrderBy(x=>x.Name))
            {
                sb.AppendLine(customer.ToString());
                sb.AppendLine("-Models:");

                if (!customer.Purchases.Any())
                    sb.AppendLine("--none");

                else
                {
                    foreach (var model in customer.Purchases.OrderBy(x=>x))
                    {
                        sb.AppendLine($"--{model.ToString()}");
                    }
                }
            }

            return sb.ToString().Trim();
        }

        public string PurchaseVehicle(string vehicleTypeName, string customerName, double budget)
        {
            var customer = dealership.Customers.Get(customerName);
            if (customer is null)
                return string.Format(OutputMessages.CustomerNotFound, customerName);

            var vehicles = dealership.Vehicles.Models.Where(x=>x.GetType().Name == vehicleTypeName).ToList();
            if (vehicles.Count==0)
                return string.Format(OutputMessages.VehicleTypeNotFound, vehicleTypeName);

            if (customer.GetType().Name==nameof(IndividualClient) && vehicleTypeName==nameof(Truck))
                return string.Format(OutputMessages.CustomerNotEligibleToPurchaseVehicle, customerName,vehicleTypeName);

            if (customer.GetType().Name == nameof(LegalEntityCustomer) && vehicleTypeName == nameof(SaloonCar))
                return string.Format(OutputMessages.CustomerNotEligibleToPurchaseVehicle, customerName, vehicleTypeName);

            var vehiclesToBuy = vehicles.Where(x => x.Price <= budget).ToList();
            if (!vehiclesToBuy.Any())
                return string.Format(OutputMessages.BudgetIsNotEnough,customerName,vehicleTypeName);

            var vehBuy = vehiclesToBuy.OrderByDescending(x => x.Price).First();
            customer.BuyVehicle(vehBuy.Model);
            vehBuy.SellVehicle(customerName);
            return string.Format(OutputMessages.VehiclePurchasedSuccessfully, customerName,vehBuy.Model);

        }

        public string SalesReport(string vehicleTypeName)
        {
            StringBuilder sb = new StringBuilder();
            var vehicles = dealership.Vehicles.Models.Where(x=>x.GetType().Name==vehicleTypeName).OrderBy(x=>x.Model).ToList();
            sb.AppendLine($"{vehicleTypeName} Sales Report:");
            foreach (var vehicle in vehicles)
            {
                sb.AppendLine($"--{vehicle.ToString()}");
            }
            sb.Append($"-Total Purchases: {vehicles.Sum(x=>x.SalesCount)}");

           return sb.ToString().TrimEnd();
        }
    }
}
