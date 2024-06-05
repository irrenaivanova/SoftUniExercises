Dictionary<string, string> passwords = new Dictionary<string, string>();
Dictionary<string, Dictionary<string, int>> students = new Dictionary<string, Dictionary<string, int>>();

while (true)
{
    string input = Console.ReadLine();
    if (input == "end of contests")
        break;

    string[] inputPasswords = input.Split(":");
    string contest = inputPasswords[0];
    string password = inputPasswords[1];

    if (!passwords.ContainsKey(contest))
    {
        passwords.Add(contest, password);
    }
    passwords[contest] = password;
}

while (true)
{
    string input = Console.ReadLine();

    if (input == "end of submissions")
        break;

    string[] inputSubmissions = input.Split("=>");
    string contest = inputSubmissions[0];
    string password = inputSubmissions[1];
    string username = inputSubmissions[2];
    int points = int.Parse(inputSubmissions[3]);

    if (!passwords.ContainsKey(contest))
        continue;
    if (!passwords.Where(x => x.Key == contest).Select(x => x.Value).Contains(password))
        continue;

    if (!students.ContainsKey(username))
    {
        students.Add(username, new Dictionary<string, int>());
        students[username].Add(contest, points);
    }
    else
    {
        if (!students[username].ContainsKey(contest))
        {
            students[username].Add(contest, points);
        }
        else if (students[username][contest] < points)
        {
            students[username][contest] = points;
        }
    }
}

students = students.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(p => p.Key, p => p.Value);

Console.WriteLine($"Best candidate is {students.First().Key} with total {students.First().Value.Values.Sum()} points.");
Console.WriteLine("Ranking:");
foreach (var item in students.OrderBy(x => x.Key))
{
    Console.WriteLine(item.Key);

    foreach (var dictionary in item.Value.OrderByDescending(x => x.Value))
    {
        Console.WriteLine($"#  {dictionary.Key} -> {dictionary.Value}");
    }
}