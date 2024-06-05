HashSet<string> cars = new HashSet<string>();

while (true)
{
    string input = Console.ReadLine();
    if (input == "END")
        break;

    string[] splitted = input.Split(", ");
    string direction = splitted[0];
    string car = splitted[1];

    if (direction == "IN")
    {
        cars.Add(car);
    }
    else
    {
        cars.Remove(car);
    }
}
if (cars.Count == 0)
    Console.WriteLine("Parking Lot is Empty");
else
    Console.WriteLine(string.Join("\n", cars));