using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IBakedFood> bakedFoods;
        private readonly ICollection<IDrink> drinks;
        private readonly ICollection<ITable> tables;
        private decimal totalIncome = 0;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type==DrinkType.Tea.ToString())
            {
                drinks.Add(new Tea(name, portion, brand));
            }
            if (type == DrinkType.Water.ToString())
            {
                drinks.Add(new Water(name, portion, brand));
            }


            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {

            if (type == "Bread")
            {
                bakedFoods.Add(new Bread(name,price));
            }
            if (type == "Cake")
            {
                bakedFoods.Add(new Cake(name,price));
            }

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == TableType.InsideTable.ToString())
            {
                tables.Add(new InsideTable(tableNumber,capacity));
            }
            if (type == TableType.OutsideTable.ToString())
            {
                tables.Add(new OutsideTable(tableNumber, capacity));
            }

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            var freeTables=tables.Where(x=>!x.IsReserved).ToList();
            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome,$"{totalIncome:f2}");
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.Where(x => x.TableNumber == tableNumber).FirstOrDefault();
     
            decimal bill = table.GetBill();
            totalIncome += bill;
            table.Clear();
            return $"Table: {tableNumber}\nBill: {bill}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.Where(x => x.TableNumber == tableNumber).FirstOrDefault();
            IDrink drink = drinks.Where(x => x.Name == drinkName && x.Brand == drinkBrand).FirstOrDefault();
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName,drinkBrand);
            }
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.Where(x => x.TableNumber == tableNumber).FirstOrDefault();
           
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            else
            {
                IBakedFood food = bakedFoods.Where(x => x.Name == foodName).FirstOrDefault();
                if (food == null)
                {
                    return string.Format(OutputMessages.NonExistentFood, foodName);
                }
                table.OrderFood(food);
                return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, food.Name);
            }
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.Where(x=>!x.IsReserved && x.Capacity>=numberOfPeople).FirstOrDefault();    
            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            table.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved,table.TableNumber, numberOfPeople);
        }
    }
}
