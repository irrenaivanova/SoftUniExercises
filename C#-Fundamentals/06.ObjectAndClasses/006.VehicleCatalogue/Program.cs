using System.Globalization;
using System.Runtime.InteropServices;

List<Vehicle> cars = new List<Vehicle>();
List<Vehicle> trucks = new List<Vehicle>();

while (true)
{
    string command = Console.ReadLine();
    if (command == "End")
        break;
    string[] inputVehicle = command.Split();

    string type = inputVehicle[0];
    string model = inputVehicle[1];
    string color = inputVehicle[2];
    double horsepower = double.Parse(inputVehicle[3]);

    if (type == "car")
    {
        type = "Car";
        cars.Add(new Vehicle(type, model, color, horsepower));
    }
    if (type == "truck")
    {
        type = "Truck";
        trucks.Add(new Vehicle(type, model, color, horsepower));
    }
}

double totalPowerCars = cars.Select(x => x.HorsePower).Sum() / cars.Count;
double totalPowerTrucks = trucks.Select(x => x.HorsePower).Sum() / trucks.Count;
if (cars.Count == 0)
    totalPowerCars = 0;
if (trucks.Count == 0)
    totalPowerTrucks = 0;

while (true)
{
    string vehicle = Console.ReadLine();
    if (vehicle == "Close the Catalogue")
        break;

    foreach (var truck in trucks)
    {
        if (truck.Model == vehicle)
        {
            Console.WriteLine(truck);
            continue;
        }
    }

    foreach (var car in cars)
    {
        if (car.Model == vehicle)
        {
            Console.WriteLine(car);
            continue;
        }
    }
}

Console.WriteLine($"Cars have average horsepower of: {totalPowerCars:f2}.");
Console.WriteLine($"Trucks have average horsepower of: {totalPowerTrucks:f2}.");

class Vehicle
{
    public Vehicle(string type, string model, string color, double horsepower)
    {
        Type = type;
        Model = model;
        Color = color;
        HorsePower = horsepower;
    }
    public string Type { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public double HorsePower { get; set; }

    public override string ToString()
    {

        return $"Type: {Type}\n" +
            $"Model: {Model}\n" +
            $"Color: {Color}\n" +
            $"Horsepower: {HorsePower}";
    }
}
