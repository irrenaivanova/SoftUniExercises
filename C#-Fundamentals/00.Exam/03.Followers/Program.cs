Dictionary<string, int> list = new();
while(true)
{
    string[] command = Console.ReadLine().Split(": ");
    if (command[0] == "Log out")
        break;

    if (command[0] == "New follower")
    {
        if (!list.ContainsKey(command[1]))
        {
            list.Add(command[1], 0);
        }
          
    }

    if (command[0] == "Like")
    {
        if (!list.ContainsKey(command[1]))
        {
            list.Add(command[1], 0);
        }
        list[command[1]] += int.Parse(command[2]);
    }

    if (command[0] == "Comment")
    {
        if (!list.ContainsKey(command[1]))
        {
            list.Add(command[1], 0);
        }
        list[command[1]]++;
    }

    if (command[0] == "Blocked")
    {
        if(!list.Remove(command[1]))
        {
            Console.WriteLine($"{command[1]} doesn't exist.");
        }
    }
}
Console.WriteLine($"{list.Count} followers");
Console.WriteLine(string.Join("\n",list.Select(x=>$"{x.Key}: {x.Value}")));