int green = int.Parse(Console.ReadLine()!);
int window = int.Parse(Console.ReadLine()!);
Queue<string> cars = new Queue<string>();
int carsCount = 0;
bool crashHappens = false;
string hittedCar = string.Empty;
char hitted = default(char);

while(true)
{
    string input = Console.ReadLine()!;
    if (input == "END")
    {
        break;
    }
    if (input == "green")
    {
        int currentGreen = green;
        while (currentGreen > 0 && cars.Count() > 0)
        {
            string currentCar = cars.Dequeue();
            currentGreen -= currentCar.Length;
            if (currentGreen > 0) 
            {
                carsCount++;
            }
            else if (currentGreen == 0)
            {
                carsCount++;
            }
            else
            {
                currentGreen += window;
                if (currentGreen >= 0)
                {
                    carsCount++;
                    break;
                }
                else
                {
                    hittedCar = currentCar;
                    hitted = hittedCar[hittedCar.Length + currentGreen];
                    crashHappens = true;
                    break;
                }
            }
        }
    }
    else
    {
       cars.Enqueue(input);
    }
    
    if(crashHappens)
    {
        break;
    }
}    


if  (crashHappens)
{
    Console.WriteLine("A crash happened!");
    Console.WriteLine($"{hittedCar} was hit at {hitted}.");
}
else
{
    Console.WriteLine("Everyone is safe.");
    Console.WriteLine($"{carsCount} total cars passed the crossroads.");
}