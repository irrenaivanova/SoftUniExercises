using System.Collections.Generic;
using System.Xml.Schema;

int n = int.Parse(Console.ReadLine());
List<Car> cars = new List<Car>();

for (int i = 0; i < n; i++)
{
    string[] newCar = Console.ReadLine().Split();
    string model = newCar[0];
    double fuelAmount = double.Parse(newCar[1]);
    double fuelConsump = double.Parse(newCar[2]);
    cars.Add(new Car(model, fuelAmount, fuelConsump));
}

while (true)
{
    string input = Console.ReadLine();
    if (input == "End")
        break;
    string[] driveCommand = input.Split();
    string model = driveCommand[1];
    double km = double.Parse(driveCommand[2]);

    if (!CanMove(cars, model, km))
    {
        Console.WriteLine($"Insufficient fuel for the drive");
    }
    else
    {
        Car currentCar = cars.FirstOrDefault(x => x.Model == model);
        currentCar.TravelDistance += km;
        currentCar.FuelAmount -= km * currentCar.FuelConsump;
    }
}
foreach (var car in cars)
{
    Console.WriteLine(car);
}


bool CanMove(List<Car> cars, string model, double km)
{
    Car currentCar = cars.FirstOrDefault(x => x.Model == model);
    if (km * currentCar.FuelConsump <= currentCar.FuelAmount)
        return true;
    else
        return false;
}

class Car
{
    public Car(string model, double fuelAmount, double fuelConsump)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsump = fuelConsump;
    }
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsump { get; set; }
    public double TravelDistance { get; set; }
    public override string ToString()
    {
        return $"{Model} {FuelAmount:f2} {TravelDistance}";
    }

}