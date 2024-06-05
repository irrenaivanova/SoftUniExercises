using _006.SpeedRacing;

int n = int.Parse(Console.ReadLine());
List<Car> cars = new();
for (int i = 0; i < n; i++)
{
    string[] inputCar = Console.ReadLine().Split();
    Car car = new Car(inputCar[0], double.Parse(inputCar[1]), double.Parse(inputCar[2])); 
    cars.Add(car);
}

while(true)
{
    string[] commandLine = Console.ReadLine().Split();
    if (commandLine[0] == "End")
        break;

    string carModel = commandLine[1];
    double amount = double.Parse(commandLine[2]);

    cars.First(x => x.Model == carModel).Drive(amount);
}

foreach (Car car in cars)
{
    Console.WriteLine(car);
}