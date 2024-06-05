string[] names = Console.ReadLine().Split();

Action<string> print = x=> Console.WriteLine(x);

foreach (var name in names)
{
    print(name);
}

