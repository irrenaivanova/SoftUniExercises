using CarManufacturer;
using System.Text;

List<Tire[]> tires = new List<Tire[]>();
List<Engine> engines = new List<Engine>();
List<Car> cars = new List<Car>();

while (true)
{
    string command = Console.ReadLine();
    if (command == "No more tires")
        break;

    string[] commandArg = command.Split();
    Tire[] currentTire = new Tire[4];
    for (int i = 0; i < commandArg.Length; i+=2)
    {
        int year = int.Parse(commandArg[i]);
        double pressure = double.Parse(commandArg[i+1]);
        currentTire[i/2] = new Tire(year, pressure);
    }
    tires.Add(currentTire);
}

while (true)
{
    string command = Console.ReadLine();
    if (command == "Engines done")
        break;
    string[] commandArg = command.Split();
    int horsePower = int.Parse(commandArg[0]);
    double cubicCapa = double.Parse(commandArg[1]);
    engines.Add(new Engine(horsePower, cubicCapa));
    
}
while (true)
{
    string command = Console.ReadLine();
    if (command == "Show special")
        break;
    string[] commandArg = command.Split();
    Car car = new Car();
    car.Make = commandArg[0];
    car.Model = commandArg[1];
    car.Year= int.Parse(commandArg[2]);
    car.FuelQuantity = int.Parse(commandArg[3]);
    car.FuelConsumption = int.Parse(commandArg[4]);
    car.Engine = engines[int.Parse(commandArg[5])];
    car.Tires = tires[int.Parse(commandArg[6])];

    cars.Add(car);
}

cars = cars.Where(x => x.Year >= 2017)
    .Where(x => x.Engine.HorsePower > 330)
    .Where(x =>x.Tires.Sum(x=>x.Pressure)>=9)
    .Where(x => x.Tires.Sum(x => x.Pressure) <= 10)
    .ToList();
    //{
    //    double sum = 0;
    //    foreach (Tire tire in x.Tires)
    //    {
    //        sum += tire.Pressure;
    //    }
    //    return sum >= 9 && sum <= 10;
    //}).ToList();

if (cars.Any())
{
    foreach (Car car in cars)
    {
        car.Drive(20);
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Make: {car.Make}");
        sb.AppendLine($"Model: {car.Model}");
        sb.AppendLine($"Year: {car.Year}");
        sb.AppendLine($"HorsePowers: {car.Engine.HorsePower}");
        sb.AppendLine($"FuelQuantity: {car.FuelQuantity:f1}");
        Console.WriteLine(sb.ToString());
    }
}

