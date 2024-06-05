int green = int.Parse(Console.ReadLine());
int window = int.Parse(Console.ReadLine());
Queue<string> cars = new Queue<string>();
int count = 0;

while (true)
{
    string command = Console.ReadLine();
    if (command == "END")
        break;
    else if (command == "green")
    {
        int currGreen = green;
        int currWindow = window;

        while (cars.Count > 0)
        {
            string currCar = cars.Peek();
            currGreen -= currCar.Length;
            if (currGreen >= 0)
            {
                count++;
                cars.Dequeue();
                if (currGreen == 0)
                    break;
            }
            else if (currGreen + currWindow >= 0)
            {
                count++;
                cars.Dequeue();
                break;
            }
            else
            {
                char hitted = currCar[currCar.Length + currGreen + currWindow];
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{currCar} was hit at {hitted}.");
                return;
            }
        }
    }
    else
    {
        cars.Enqueue(command);
    }
}
Console.WriteLine($"Everyone is safe.");
Console.WriteLine($"{count} total cars passed the crossroads.");