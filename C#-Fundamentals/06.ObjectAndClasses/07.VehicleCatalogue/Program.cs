string input = Console.ReadLine();

List<Car> cars = new List<Car>();
List<Truck> trucks = new List<Truck>();

while (input != "end")
{
    string[] splitted = input.Split("/");
    string type = splitted[0];
    string brand = splitted[1];
    string model = splitted[2];
    int power = int.Parse(splitted[3]);

    if (type == "Car")
    {
        Car car = new Car();
        car.Brand = brand;
        car.Model = model;
        car.HorsePower = power;
        cars.Add(car);
    }

    if (type == "Truck")
    {
        Truck truck = new Truck();
        truck.Brand = brand;
        truck.Model = model;
        truck.Weight = power;
        trucks.Add(truck);
    }
    trucks = trucks.OrderBy(x => x.Brand).ToList();
    cars = cars.OrderBy(x => x.Brand).ToList();

    input = Console.ReadLine();
}
if (cars.Count > 0)
    Console.WriteLine("Cars:");
foreach (var car in cars)
{
    Console.WriteLine(car);
}
if (trucks.Count > 0)
    Console.WriteLine("Trucks:");
foreach (var truck in trucks)
{
    Console.WriteLine(truck);
}


class Truck
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Weight { get; set; }
    public override string ToString()
    {
        return $"{Brand}: {Model} - {Weight}kg";
    }
}
class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int HorsePower { get; set; }
    public override string ToString()
    {
        return $"{Brand}: {Model} - {HorsePower}hp";
    }
}