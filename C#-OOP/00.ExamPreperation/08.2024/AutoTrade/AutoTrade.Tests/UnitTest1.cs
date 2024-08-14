using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Reflection;
using AutoTrade;

namespace AutoTrade.Tests
{
    [TestFixture]
    public class DealerShopTests
    {
        private Vehicle vehicle;

        [SetUp]
        public void Setup()
        {
            vehicle = new Vehicle("Audi", "A6", 2016);
        }

        [Test]
        public void IfCostructorOfVehicleWorksProperly()
        {
            Assert.AreEqual("Audi", vehicle.Make);
            Assert.AreEqual("A6", vehicle.Model);
            Assert.AreEqual(2016, vehicle.Year);

            string expected = $"2016 Audi A6";
            Assert.AreEqual(expected, vehicle.ToString());
        }

        [Test]
        public void IfCostructorOfDealerShopWorksProperly()
        {
            var shop = new DealerShop(5);
            Assert.AreEqual(5, shop.Capacity);
            Assert.AreEqual(0,shop.Vehicles.Count); 
        }


        [TestCase(0)]
        [TestCase(-5)]

        public void IFCapacityInvalidNumberThrowException(int cap)
        {
            Assert.Throws<ArgumentException>(() => new DealerShop(cap));
        }

        [Test]
        public void IfCapacityFullThrowException()
        {
            var shop = new DealerShop(1);
            shop.AddVehicle(vehicle);
            Assert.Throws<InvalidOperationException>(() => shop.AddVehicle(new Vehicle("BMV", "jj", 2015)));
        }

        [Test]
        public void IfAddingVehicleWorkProperly()
        {
            var shop = new DealerShop(2);
            string actual = shop.AddVehicle(vehicle);
            string expected = $"Added 2016 Audi A6";
            Assert.AreEqual(1,shop.Vehicles.Count());
            Assert.AreEqual(expected , actual);
        }

        [Test]
        public void IfRemovingWorkProperly()
        {
            var shop = new DealerShop(2);
            shop.AddVehicle(vehicle);
            var vehicle2 = new Vehicle("BMV", "jj", 2015);
            bool ifRemoved1 = shop.SellVehicle(vehicle2);
            bool ifRemoved =  shop.SellVehicle(vehicle);
            Assert.AreEqual(0,shop.Vehicles.Count());
            Assert.AreEqual(true,ifRemoved);
            Assert.AreEqual(false, ifRemoved1);
        }

        [Test]
        public void IfInventoryReportWorkProperly()
        {
            var shop = new DealerShop(2);
            shop.AddVehicle(vehicle);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inventory Report");
            sb.AppendLine($"Capacity: 2");
            sb.AppendLine($"Vehicles: 1");
            sb.AppendLine($"2016 Audi A6");
            string expected = sb.ToString().TrimEnd();

            Assert.AreEqual(expected, shop.InventoryReport());

        }
    }
}

