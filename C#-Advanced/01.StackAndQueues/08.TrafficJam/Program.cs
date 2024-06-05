int n = int.Parse(Console.ReadLine());
int total = 0;

Queue<string> cars = new Queue<string>();

while (true)
{
    int passes = 0;
    string command = Console.ReadLine();
    if (command == "end")
        break;
    else if (command == "green")
    {
        while (cars.Count > 0 && passes < n)
        {
            Console.WriteLine($"{cars.Dequeue()} passed!");
            passes++;
        }
        total += passes;
        passes = 0;
    }
    else
    {
        cars.Enqueue(command);
    }
}
Console.WriteLine($"{total} cars passed the crossroads.");