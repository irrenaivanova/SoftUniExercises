double[] prices = Console.ReadLine().Split(", ").Select(double.Parse).Select(s=>s*1.2).ToArray();

Console.WriteLine(string.Join("\n",prices.Select(x=>x.ToString("f2"))));