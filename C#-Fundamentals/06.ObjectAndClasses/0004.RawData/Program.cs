int n = int.Parse(Console.ReadLine());
List<Car> cars = new List<Car>();

for (int i = 0; i < n; i++)
{
    string[] newCar = Console.ReadLine().Split();
    cars.Add(new Car(newCar[0], int.Parse(newCar[1]), int.Parse(newCar[2]), int.Parse(newCar[3]), newCar[4]));
}
string type = Console.ReadLine();

if (type == "flamable")
{
    foreach (var car in cars)
    {
        if (car.Cargo.Type == type && car.Engine.Power > 250)
            Console.WriteLine(car.Model); ;
    }
}
if (type == "fragile")
{
    foreach (var car in cars)
    {
        if (car.Cargo.Type == type && car.Cargo.Weight < 1000)
            Console.WriteLine(car.Model);
    }
}

class Cargo
{
    public int Weight { get; set; }
    public string Type { get; set; }
}

class Engine
{
    public int Speed { get; set; }
    public int Power { get; set; }
}
class Car
{
    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType)
    {
        Model = model;
        Engine.Speed = engineSpeed;
        Engine.Power = enginePower;
        Cargo.Weight = cargoWeight;
        Cargo.Type = cargoType;
    }
    public string Model { get; set; }
    public Engine Engine { get; set; } = new Engine();
    public Cargo Cargo { get; set; } = new Cargo();
}