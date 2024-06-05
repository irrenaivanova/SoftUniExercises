List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
int maxCap = int.Parse(Console.ReadLine());

while (true)
{
    string commandLine = Console.ReadLine();
    if (commandLine == "end")
        break;

    List<string> command = commandLine.Split().ToList();

    if (command[0] == "Add")
        wagons.Add(int.Parse(command[1]));

    else
    {
        int newPass = int.Parse(command[0]);
        for (int i = 0; i < wagons.Count; i++)
        {
            if (newPass <= maxCap - wagons[i])
            {
                wagons[i] += newPass;
                break;
            }
        }
    }
}
Console.WriteLine(string.Join(" ", wagons));