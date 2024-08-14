using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private  ICollection<IBakedFood> foodOrders;
        private  ICollection<IDrink> drinkOrders;
        private int capacity;
        public int numberOfPeople;
        public Table(int tablenumber, int capacity, decimal priceperPerson )
        {
            TableNumber = tablenumber;
            Capacity = capacity;
            PricePerPerson = priceperPerson;
            foodOrders = new List<IBakedFood>();
            drinkOrders= new List<IDrink>();
        }
        public int TableNumber {get;private set;}

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price => NumberOfPeople*PricePerPerson;

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            numberOfPeople = 0;
            IsReserved = false;
        }

        public decimal GetBill() => drinkOrders.Select(x => x.Price).Sum() + foodOrders.Select(x => x.Price).Sum()+ Price;

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");
            return sb.ToString().Trim();
        }

        public void OrderDrink(IDrink drink) => drinkOrders.Add(drink);


        public void OrderFood(IBakedFood food) => foodOrders.Add(food);


        public void Reserve(int numberOfPeople)
        {
            if (numberOfPeople <= 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
            }
            
            this.numberOfPeople = numberOfPeople;
        }
    }
}
