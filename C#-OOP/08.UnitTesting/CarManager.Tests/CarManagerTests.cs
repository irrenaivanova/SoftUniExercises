namespace Tests;


using CarManager;
using NUnit.Framework;
using System;

[TestFixture]
public class CarManagerTests
{
    private Car car;
    [SetUp]
    public void SetUp()
    {
        car = new Car("Mercedes", "S63", 7.5, 50.0);
    }
    
    [Test]
    public void CarShouldBeSetSuccessfully()
    {
        Assert.AreEqual("Mercedes", car.Make);
        Assert.AreEqual("S63", car.Model);
        Assert.AreEqual(7.5, car.FuelConsumption);
        Assert.AreEqual(50.0, car.FuelCapacity);
        Assert.AreEqual(0, car.FuelAmount);
    }
    

    [TestCase(null)]
    [TestCase("")]
    public void When_MakeIsNullOrEMpty_ShouldThrowException(string make)
    {
        Assert.Throws<ArgumentException>(() => { new Car(make, "S63", 7.5, 50.0); }, "Make cannot be null or empty!");

    }

    [TestCase(null)]
    [TestCase("")]
    public void When_ModelIsNullOrEMpty_ShouldThrowException(string model)
    {
        Assert.Throws<ArgumentException>(() => { new Car("BMV",model, 7.5, 50.0); }, "Model cannot be null or empty!");

    }

    [TestCase(0)]
    [TestCase(-5)]
    public void When_FuelCOnsumplIsNullOrNegative_ShouldThrowException(int fuelCons)
    {
        Assert.Throws<ArgumentException>(() => { new Car("BMV", "kdfkdh", fuelCons, 50.0); }, 
            "Fuel consumption cannot be zero or negative!");
    }

   
    [TestCase(-5)]
    [TestCase(0)]
    public void When_FuelIsNegative_ShouldThrowException(int fuelCapc)
    {
        Assert.Throws<ArgumentException>(() => { new Car("BMV", "kdfkdh", 2.5, fuelCapc); },
            "Fuel capacity cannot be zero or negative!");
    }

    [Test]
    public void CarFuelAmountShouldThrowExceptionIfIsNegative()
    {
        Assert.Throws<InvalidOperationException>(()
            => car.Drive(12), "Fuel amount cannot be negative!");
    }

    [TestCase(0)]
    [TestCase(-5)]
    public void When_TryingToRefillWIthZeroOrNegativeAmount_ShouldThrowException(int fuel)
    {
        Assert.Throws<ArgumentException>(() => {car.Refuel(fuel); },
            "Fuel amount cannot be zero or negative!");
    }

    [TestCase(50)]
    [TestCase(60)]
    public void When_Refilling_ShouldNotBeMoreThanCapacity(double fuel)
    {
        car.Refuel(fuel);
        double expected = car.FuelCapacity;
        Assert.AreEqual(expected, car.FuelAmount);
    }
    
    [TestCase(10)]
    [TestCase(20)]
    public void When_Refilling_ShouldThePropertyBeSetProperly(double fuel)
    {
        car.Refuel(fuel);
        Assert.AreEqual(fuel, car.FuelAmount);
    }
    [Test]
    public void When_Driving_ShouldThePropertyBeSetProperly()
    {
        double expected = 2.5;
        car.Refuel(10);
        car.Drive(100);
        Assert.AreEqual(expected, car.FuelAmount);
    }
    [Test]
    public void When_TryingDrivingWithLessFuelNeeded_ShouldThrowException()
    {
        car.Refuel(1);
        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        Assert.AreEqual(ex.Message, "You don't have enough fuel to drive!");
    }
}