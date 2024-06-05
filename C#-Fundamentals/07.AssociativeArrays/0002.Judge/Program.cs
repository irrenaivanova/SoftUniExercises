Dictionary<string, Dictionary<string, int>> contests = new Dictionary<string, Dictionary<string, int>>();
Dictionary<string, int> students = new Dictionary<string, int>();

while (true)
{
    string command = Console.ReadLine();
    if (command == "no more time")
        break;

    string[] input = command.Split(" -> ");
    string student = input[0];
    string contest = input[1];
    int points = int.Parse(input[2]);
    bool isBetterResult = false;
    bool isWorstResult = false;
    int pointsToBedeleted = 0;

    if (!contests.ContainsKey(contest))
    {
        contests.Add(contest, new Dictionary<string, int>());
        contests[contest].Add(student, points);

    }
    else
    {
        if (!contests[contest].ContainsKey(student))
        {
            contests[contest].Add(student, points);
        }
        else
        {
            if (contests[contest][student] < points)
            {
                pointsToBedeleted = contests[contest][student];
                contests[contest][student] = points;
                isBetterResult = true;

            }
            else
                isWorstResult = true;
        }
    }

    if (!students.ContainsKey(student))
    {
        students.Add(student, 0);
    }
    if (!isWorstResult)
    {
        students[student] += points;
    }

    if (isBetterResult)
    {
        students[student] -= pointsToBedeleted;
    }
}

//contests = contests.OrderByDescending(x => x.Value.Values)
//.ThenBy(x => x.Value.Keys)
//.ToDictionary(x => x.Key, x => x.Value);

students = students.OrderByDescending(x => x.Value)
    .ThenBy(x => x.Key)
    .ToDictionary(x => x.Key, p => p.Value);



foreach (var item in contests)
{
    Console.WriteLine($"{item.Key}: {item.Value.Count} participants");
    int n = 1;
    foreach (var pair in item.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
    {
        Console.WriteLine($"{n}. {pair.Key} <::> {pair.Value}");
        n++;
    }
}
Console.WriteLine($"Individual standings:");
int m = 1;
foreach (var item in students)
{
    Console.WriteLine($"{m}. {item.Key} -> {item.Value}");
    m++;
}