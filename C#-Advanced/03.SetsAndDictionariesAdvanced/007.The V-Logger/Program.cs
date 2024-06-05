using System.Collections.Generic;

List<Person> persons = new List<Person>();
while (true)
{
    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if (input[0] == "Statistics")
        break;

    if (input[1] == "joined"
        && !persons.Select(x => x.Name).Contains(input[0]))
    {
        persons.Add(new Person(input[0], new List<string>(), new List<string>()));

    }
    else if (input[1] == "followed")
    {
        string first = input[0];
        string second = input[2];

        if (first.Equals(second))
            continue;


        if (!(persons.Select(x => x.Name).Contains(first)
            && persons.Select(x => x.Name).Contains(second)))
            continue;

        if (persons.First(x => x.Name == first).Following.Contains(second))
            continue;

        //if (persons.First(x => x.Name == second).Following.Contains(first))
        //    continue;

        persons.First(x => x.Name == first).Following.Add(second);
        persons.First(x => x.Name == second).Followers.Add(first);
    }
}
persons = persons.OrderByDescending(x => x.Followers.Count)
    .ThenBy(x => x.Following.Count)
    .ToList();
Person firstPerson = persons.First();

Console.WriteLine($"The V-Logger has a total of {persons.Count} vloggers in its logs.");
Console.WriteLine($"1. {firstPerson.Name} : {firstPerson.Followers.Count} followers, {firstPerson.Following.Count} following");
foreach (string follower in firstPerson.Followers.OrderBy(x => x))
{
    Console.WriteLine($"*  {follower}");
}
int n = 2;

foreach (Person person in persons.Where(x => x.Name != firstPerson.Name))
{
    Console.WriteLine($"{n}. {person.Name} : {person.Followers.Count} followers, {person.Following.Count} following");
    n++;
}

public class Person
{
    public Person(string name, List<string> followers, List<string> following)
    {
        Name = name;
        Followers = followers;
        Following = following;
    }
    public string Name { get; set; }

    public List<string> Followers { get; set; } = new List<string>();

    public List<string> Following { get; set; } = new List<string>();
}
