//List<int> numbers = Console.ReadLine().Split(", ").Select((string x) => int.Parse(x)).ToList();

List<int> numbers = Console.ReadLine().Split(", ")
    .Select((string x) => { return int.Parse(x); })
    .Where(x => x % 2 == 0)
    .OrderBy(x => x)
    .ToList();

Console.WriteLine(string.Join(", ",numbers));
