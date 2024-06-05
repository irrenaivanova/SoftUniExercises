using _008.CarSalesman;

int n = int.Parse(Console.ReadLine());
List<Engine> engines = new List<Engine>();
for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
    Engine engine = new(input[0], int.Parse(input[1]));
    if (input.Length == 4)
    {
        engine.Displacement = int.Parse(input[2]);
        engine.Efficiency = input[3];
    }
    if (input.Length == 3)
    {
        if (int.TryParse(input[2],out _))
        {
            engine.Displacement = int.Parse(input[2]);
        }
        else
        {
            engine.Efficiency = input[2];
        }
    }
    engines.Add(engine);
}
int m = int.Parse(Console.ReadLine());
List<Car> cars = new List<Car>();

for (int i = 0; i < m; i++)
{
    string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
    Engine engine = engines.FirstOrDefault(x => x.Model == input[1]);
    Car car = new Car(input[0], engine);

    if (input.Length == 4)
    {
        car.Weight = int.Parse(input[2]);
        car.Color = input[3];
    }
    if (input.Length == 3)
    {
        if (int.TryParse(input[2], out _))
        {
            car.Weight = int.Parse(input[2]);
        }
        else
        {
            car.Color = input[2];
        }
    }
    cars.Add(car);
}
Console.WriteLine(string.Join("\n",cars));
