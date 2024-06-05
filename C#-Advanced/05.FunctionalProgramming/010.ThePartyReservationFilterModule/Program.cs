using System.Xml.Linq;

List<string> names = Console.ReadLine().Split().ToList();
List<Filter> filters = new List<Filter>();

while (true)
{
    string commandLine = Console.ReadLine();

    if (commandLine == "Print")
    {
        foreach (Filter filter1 in filters)
        {
            Predicate<string> predicate = GetMatch(filter1.Name, filter1.Value);
            names = names.Where(x=>!predicate(x)).ToList();
        }
        Console.WriteLine(string.Join(" ",names));
        break;
    }

    string[] commands = commandLine.Split(";");
    string command = commands[0];
    string filter = commands[1];
    string value = commands[2];

    if (command.Contains("Add"))
    {
        filters.Add( new Filter(){ Name=filter,Value=value});
    } 
    
    if (command.Contains("Remove"))
    {
        filters.Remove(filters.First(x => x.Name == filter && x.Value==value));
    }
}

Predicate<string> GetMatch(string name, string value)
{
    if (name == "Starts with")
    {
        return x=>x.StartsWith(value);
    }
    else if (name == "Ends with")
    {
        return x => x.EndsWith(value);
    }
    else if (name == "Length")
    {
        int valueInt = int.Parse(value);
        return x => x.Length == valueInt;
    }
    else if (name == "Contains")
    {
        return x => x.Contains(value);
    }
    else return default;
}

class Filter
{
    public string Name;
    public string Value;
}
