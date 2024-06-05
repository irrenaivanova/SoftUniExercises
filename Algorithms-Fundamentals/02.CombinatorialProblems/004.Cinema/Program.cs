List<string> people = Console.ReadLine().Split(", ").ToList();
string[] comb = new string[people.Count];
List<string> used = new();
List<int> places = new();

while (true)
{
    string[] input = Console.ReadLine().Split(" - ");
    if (input[0] == "generate")
    {
        break;
    }
    string name = input[0];
    int place = int.Parse(input[1])-1;
    comb[place] = name;
    people.Remove(name);
    places.Add(place);
}
PrintTheComb(0);

void PrintTheComb(int start)
{
    for (int i = start; i < people.Count; i++)
    {
        if (places.Contains(start))
        {
            start++;
        }
    }
    
    if (start==comb.Length)
    {
        Console.WriteLine(string.Join(" ", comb));
        return;
    }

    for (int i = 0; i < people.Count; i++)
    {
        if (!used.Contains(people[i]))
        {
            comb[start] = people[i];
            used.Add(people[i]);
            PrintTheComb(start + 1);
            used.Remove(people[i]);
        }
    }
}

