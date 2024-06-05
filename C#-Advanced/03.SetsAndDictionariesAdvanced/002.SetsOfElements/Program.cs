int[] count = Console.ReadLine().Split().Select(int.Parse).ToArray();
List<int> first = new List<int>();
List<int> second = new List<int>();

for (int i = 0; i < count[0]; i++)
{
    first.Add(int.Parse(Console.ReadLine()));
}
for (int i = 0; i < count[1]; i++)
{
    second.Add(int.Parse(Console.ReadLine()));
}

List<int> third = new List<int>();
third = first.Intersect(second).Distinct().ToList();
Console.WriteLine(string.Join(" ", third));