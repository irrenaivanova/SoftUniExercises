Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

while (true)
{
    string command = Console.ReadLine();
    if (command == "end")
        break;
    string[] infoStudent = command.Split(" : ");
    string course = infoStudent[0];
    string student = infoStudent[1];

    if (!courses.ContainsKey(course))
    {
        courses.Add(course, new List<string>());
    }
    courses[course].Add(student);
}

foreach (var item in courses)
{
    Console.WriteLine($"{item.Key}: {item.Value.Count}");
    foreach (var name in item.Value)
    {
        Console.WriteLine($"-- {name}");
    }
}