string[] names = Console.ReadLine().Split();

Action<string[], string > print = (x,y) =>
    {
        foreach (var item in x)
        {
            Console.WriteLine($"{y} {item}");
        }
    };
string title = Console.ReadLine();
print(names,title);