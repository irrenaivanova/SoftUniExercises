Dictionary<string, List<string>> employees = new Dictionary<string, List<string>>();

while (true)
{
    string command = Console.ReadLine();
    if (command == "End")
        break;
    string[] employee = command.Split(" -> ");
    string company = employee[0];
    string iD = employee[1];

    if (!employees.ContainsKey(company))
    {
        employees.Add(company, new List<string>() { iD });
    }
    else
    {
        if (!employees[company].Contains(iD))
            employees[company].Add(iD);
    }
}
foreach (var item in employees)
{
    Console.WriteLine($"{item.Key}");
    foreach (var employee in item.Value)
    {
        Console.WriteLine($"-- {employee}");
    }
}