int greenStart = int.Parse(Console.ReadLine());
int free= int.Parse(Console.ReadLine());  
Queue<string>cars = new Queue<string>();
int count = 0;
while(true)
{
    string input = Console.ReadLine();
    if (input == "END")
    {
        break;
    }
    else if (input == "green")
    {
        int green = greenStart;
        while (green>0 && cars.Any())
        {
            string car = cars.Dequeue();
            green -= car.Length;
            if (green >= 0)
            {
                count++;
            }
            else 
            {
                if (green + free >= 0)
                {
                    count++;
                    break;
                }

                int index = car.Length - Math.Abs(green + free);
                char c = car[index];
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{car} was hit at {c}.");
                return;
            }
        }
    }
    else
    {
        cars.Enqueue(input);
    }
}
Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{count} total cars passed the crossroads.");