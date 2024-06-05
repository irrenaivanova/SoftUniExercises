Predicate<string> filter = s => char.IsUpper(s[0]) && char.IsLetter(s[0]);

string[] words = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Where(x=>filter(x)).ToArray();

Console.WriteLine(string.Join("\n",words));
