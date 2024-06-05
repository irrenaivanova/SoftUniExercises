Queue<string> people = new Queue<string>();

while (true)
{
    string command = Console.ReadLine();

    if (command == "Paid")
    {
        while (people.Count > 0)
        {
            Console.WriteLine(people.Dequeue());
        }
    }
    else if (command == "End")
    {
        Console.WriteLine($"{people.Count} people remaining.");
        return;
    }
    else
    {
        people.Enqueue(command);
    }
}