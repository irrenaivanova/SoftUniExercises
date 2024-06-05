int n= int.Parse(Console.ReadLine());

//string[]names =Console.ReadLine().Split().Where(x=>x.Count()<=n).ToArray();

//Console.WriteLine(string.Join(Environment.NewLine,names));

string[]names =Console.ReadLine().Split().ToArray();

Action<string[], int> print = (names, n) =>
{
	foreach (string name in names)
	{
		if (name.Length <= n)
		{
			Console.WriteLine(name);
		}
	}
};

print(names, n);