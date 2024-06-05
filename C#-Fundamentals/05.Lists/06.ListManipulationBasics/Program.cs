var list = Console.ReadLine().Split().Select(int.Parse).ToList();
while (true)
{
    string commandLine = Console.ReadLine();
    var command = commandLine.Split().ToList();
    if (commandLine == "end")
        break;

    switch (command[0])
    {
        case "Add":
            list.Add(int.Parse(command[1])); break;
        case "Remove":
            list.Remove(int.Parse(command[1])); break;
        case "RemoveAt":
            list.RemoveAt(int.Parse(command[1])); break;
        case "Insert":
            list.Insert(int.Parse(command[2]), int.Parse(command[1])); break;
    }
}

Console.WriteLine(string.Join(" ", list));