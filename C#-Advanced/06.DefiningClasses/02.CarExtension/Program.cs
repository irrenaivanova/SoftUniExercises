using _06.DefiningClasses;
using CarManufacturer;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car newCar = new Car();
            newCar.Make = "hsgdsgd";
            newCar.Model = "MK3";
            newCar.Year = 1992;
            newCar.FuelConsumption = 200;
            newCar.FuelQuantity = 200;
            newCar.Drive(0.5);
            Console.WriteLine(newCar.WhoAmI());

        }
    }
}
