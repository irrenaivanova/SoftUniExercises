Dictionary<string, int> students = new Dictionary<string, int>();
Dictionary<string, int> languages = new Dictionary<string, int>();

while (true)
{
    string command = Console.ReadLine();
    if (command == "exam finished")
        break;
    string[] participants = command.Split("-");

    if (participants.Length == 3)
    {
        string name = participants[0];
        string language = participants[1];
        int points = int.Parse(participants[2]);

        if (!languages.ContainsKey(language))
        {
            languages.Add(language, 0);
        }
        languages[language]++;


        if (!students.ContainsKey(name))
        {
            students.Add(name, points);
        }
        else
        {
            if (students[name] < points)
                students[name] = points;

        }
    }
    if (participants.Length == 2)
    {
        string nameToBanned = participants[0];
        if (students.ContainsKey(nameToBanned))
        {
            students.Remove(nameToBanned);
        }
    }
}
Console.WriteLine("Results:");

foreach (var item in students.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{item.Key} | {item.Value}");
}
Console.WriteLine("Submissions:");
foreach (var item in languages.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{item.Key} - {item.Value}");
}