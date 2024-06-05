var list = Console.ReadLine().Split().Select(int.Parse).ToList();
while (true)
{
    bool isChanged = false;
    string commandLine = Console.ReadLine();
    var command = commandLine.Split().ToList();
    if (commandLine == "end")
        break;

    switch (command[0])
    {
        case "Contains":
            IfContains(list, int.Parse(command[1])); break;
        case "PrintEven":
            PrintEven(list); break;
        case "PrintOdd":
            PrintOdd(list); break;
        case "GetSum":
            GetSum(list); break;
        case "Filter":
            Filter(list, command[1], int.Parse(command[2])); break;
        case "Add":
            {
                list.Add(int.Parse(command[1]));
                isChanged = true;
            }
            break;
        case "Remove":
            {
                list.Remove(int.Parse(command[1]));
                isChanged = true;
            }
            break;
        case "RemoveAt":
            {
                list.RemoveAt(int.Parse(command[1]));
                isChanged = true;
            }
            break;
        case "Insert":
            {
                list.Insert(int.Parse(command[2]), int.Parse(command[1]));
                isChanged = true;
            }
            break;
    }
    if (isChanged)
        Console.WriteLine(string.Join(" ", list));
}

void Filter(List<int> list, string command, int number)
{
    List<int> filtered = new List<int>();
    for (int i = 0; i < list.Count; i++)
    {
        switch (command)
        {
            case "<":
                if (list[i] < number)
                    filtered.Add(list[i]); break;
            case ">":
                if (list[i] > number)
                    filtered.Add(list[i]); break;
            case "<=":
                if (list[i] <= number)
                    filtered.Add(list[i]); break;
            case ">=":
                if (list[i] >= number)
                    filtered.Add(list[i]); break;

        }
    }
    Console.WriteLine(string.Join(" ", filtered));
}



void GetSum(List<int> list)
{
    int sum = 0;
    for (int i = 0; i < list.Count; i++)
    {
        sum += list[i];
    }
    Console.WriteLine(sum);
}
void PrintEven(List<int> list)
{
    List<int> even = new List<int>();
    foreach (int i in list)
    {
        if (i % 2 == 0)
            even.Add(i);
    }
    Console.WriteLine(string.Join(" ", even));
}
void PrintOdd(List<int> list)
{
    List<int> odd = new List<int>();
    foreach (int i in list)
    {
        if (i % 2 == 1)
            odd.Add(i);
    }
    Console.WriteLine(string.Join(" ", odd));
}
void IfContains(List<int> list, int number)
{
    bool isFound = false;
    for (int i = 0; i < list.Count; i++)
    {
        if (list[i] == number)
        {
            isFound = true;
            break;
        }
    }
    if (isFound)
        Console.WriteLine("Yes");
    else
        Console.WriteLine("No such number");
}

