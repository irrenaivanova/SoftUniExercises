using System.Security.Cryptography.X509Certificates;

Dictionary<string, string> passwords = new();
Dictionary<string, Dictionary<string, int>> candidates = new();

while (true)
{
    string input = Console.ReadLine();
    if (input == "end of contests")
        break;

    string[] splitted = input.Split(":");
    if (!passwords.ContainsKey(splitted[0]))
    {
        passwords.Add(splitted[0], splitted[1]);
    }
}

while (true)
{
    string input = Console.ReadLine();
    if (input == "end of submissions")
        break;

    string[] splitted = input.Split("=>");
    string exam = splitted[0];
    string password = splitted[1];
    string name = splitted[2];
    int points = int.Parse(splitted[3]);

    if (!passwords.ContainsKey(exam))
        continue;
    if (passwords.ContainsKey(exam) && passwords[exam] != password)
        continue;

    if (!candidates.ContainsKey(name))
    {
        candidates.Add(name, new Dictionary<string, int>());
    }
    if (!candidates.First(x => x.Key == name).Value.ContainsKey(exam))
    {
        candidates[name].Add(exam, points);
    }
    if (candidates[name][exam] < points)
    {
        candidates[name][exam] = points;
    }
}

candidates = candidates
    .OrderByDescending(x => x.Value.Values.Sum())
    .ToDictionary(x => x.Key, x => x.Value);

Console.WriteLine($"Best candidate is {candidates.First().Key} with total {candidates.First().Value.Values.Sum()} points.");
Console.WriteLine("Ranking:");
foreach (var candidate in candidates
                    .OrderBy(x => x.Key))

{
    Console.WriteLine(candidate.Key);
    foreach (var exam in candidate.Value.OrderByDescending(x => x.Value))
    {
        Console.WriteLine($"#  {exam.Key} -> {exam.Value}");
    }
}
