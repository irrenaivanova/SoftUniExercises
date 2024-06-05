List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
while (true)
{
    string commandLine = Console.ReadLine();
    if (commandLine == "End")
        break;
    List<string> command = commandLine.Split().ToList();
    switch (command[0])
    {
        case "Add": list.Add(int.Parse(command[1])); break;
        case "Insert":
            if (int.Parse(command[2]) >= list.Count || int.Parse(command[2]) < 0)
            { Console.WriteLine("Invalid index"); }
            else
            {
                list.Insert(int.Parse(command[2]), int.Parse(command[1]));
            }
            break;
        case "Remove":
            if (int.Parse(command[1]) >= list.Count || int.Parse(command[1]) < 0)
            { Console.WriteLine("Invalid index"); }
            else
            {
                list.RemoveAt(int.Parse(command[1]));
            }
            break;
        case "Shift":
            if (command[1] == "left")
                ShiftLeft(list, int.Parse(command[2]));
            if (command[1] == "right")
                ShiftRight(list, int.Parse(command[2]));
            break;
    }
}
Console.WriteLine(string.Join(" ", list));

List<int> ShiftLeft(List<int> list, int number)
{
    for (int i = 1; i <= number; i++)
    {
        list.Add(list[0]);
        list.Remove(list[0]);
    }
    return list;
}
List<int> ShiftRight(List<int> list, int number)
{
    for (int i = 1; i <= number; i++)
    {
        list.Insert(0, list[list.Count - 1]);
        list.RemoveAt(list.Count - 1);
    }
    return list;
}

