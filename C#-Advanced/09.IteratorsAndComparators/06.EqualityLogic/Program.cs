using _06.EqualityLogic;

SortedSet<Person> list = new();
HashSet<Person> set = new();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split();
    list.Add(new Person(input[0], int.Parse(input[1])));
    set.Add(new Person(input[0], int.Parse(input[1])));
}
Console.WriteLine(list.Count);
Console.WriteLine(set.Count);