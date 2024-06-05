List<string> names = Console.ReadLine().Split().ToList();

while(true)
{
    string[] commandLine = Console.ReadLine().Split();
    string command = commandLine[0];
    if (command == "Party!")
        break;

    string condition = commandLine[1];
    string value = commandLine[2];
    
    Predicate<string> predicate = GetMatch(condition,value);

    if (command == "Remove")
    { 
        names = names.Where(x=>!predicate(x)).ToList();
    }
    if (command == "Double")
    {
        for (int i = 0; i < names.Count; i++)
        {
            if (predicate(names[i]))
            { 
                names.Insert(i, names[i]);
                i++;
            }
        }
        
    }
}
Predicate<string> GetMatch(string condition, string value)
{
    if (condition == "StartsWith")
    {
        return x => x.IndexOf(value) == 0;
    }
    else if (condition == "EndsWith")
    {
        return x => x.IndexOf(value)+ value.Length == x.Length;
    }
    else if (condition == "Length")
    {
        int valueInt = int.Parse(value);
        return x => x.Length == valueInt;
    }
    else
        return default;
}

if (names.Count>0)
    Console.WriteLine($"{string.Join(", ",names)} are going to the party!");
else
    Console.WriteLine("Nobody is going to the party!");

