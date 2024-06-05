List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

while (true)
{
    string commandLine = Console.ReadLine();

    if (commandLine == "end")
        break;

    List<string> command = commandLine.Split().ToList();
    if (command[0] == "Delete")
    {
        list.RemoveAll(x => x == int.Parse(command[1]));
    }
    else if (command[0] == "Insert")
    {
        list.Insert(int.Parse(command[2]), int.Parse(command[1]));
    }
}
Console.WriteLine(string.Join(" ", list));