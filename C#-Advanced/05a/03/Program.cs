int minV = Console.ReadLine().Split().Select(int.Parse).Aggregate((a, b) => (Math.Min(a, b)));

Console.WriteLine(minV);

 

