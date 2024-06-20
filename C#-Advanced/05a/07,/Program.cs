int n = int.Parse(Console.ReadLine());
List<string> list = Console.ReadLine().Split().ToList();

Console.WriteLine(string.Join("\n",list.Where(x=>x.Length==n)));