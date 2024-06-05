Dictionary<string, string> abonats = new Dictionary<string, string>();
int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] commandLine = Console.ReadLine().Split();

    if (commandLine[0] == "register")
    {
        string name = commandLine[1];
        string plateNumber = commandLine[2];

        if (!abonats.ContainsKey(name))
        {
            abonats.Add(name, plateNumber);
            Console.WriteLine($"{name} registered {plateNumber} successfully");
        }
        else
            Console.WriteLine($"ERROR: already registered with plate number {plateNumber}");
    }
    else if (commandLine[0] == "unregister")
    {
        string name = commandLine[1];

        if (!abonats.ContainsKey(name))
        {
            Console.WriteLine($"ERROR: user {name} not found");
        }
        else
        {
            abonats.Remove(name);
            Console.WriteLine($"{name} unregistered successfully");
        }

    }
}
foreach (var item in abonats)
{
    Console.WriteLine($"{item.Key} => {item.Value}");
}