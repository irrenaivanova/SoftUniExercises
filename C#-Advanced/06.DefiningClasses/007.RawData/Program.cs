using _007.RawData;

int n = int.Parse(Console.ReadLine());
List<Car> cars = new();

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split();
    Car car = new(input[0], int.Parse(input[1]), int.Parse(input[2])
        ,int.Parse(input[3]), input[4]
        , float.Parse(input[5]), int.Parse(input[6])
        ,float.Parse(input[7]), int.Parse(input[8])
        , float.Parse(input[9]), int.Parse(input[10])
        , float.Parse(input[11]), int.Parse(input[12]));
    cars.Add(car);
}
string filter = Console.ReadLine();
if (filter=="fragile")
{
    cars = cars.Where(x => x.Cargo.Type == filter).Where(x =>
    {
        foreach (var tire in x.Tires)
        {
            if (tire.TirePress < 1)
                return true;
        }
        return false;
    }).ToList();
}
if (filter=="flammable")
{
    cars = cars.Where(x=>x.Cargo.Type==filter).Where(x=>x.Engine.Power>250).ToList();
}
foreach (Car car in cars)
{
    Console.WriteLine(car.Model);
}
