using _04.Froggy;

Lake lake = new(Console.ReadLine().Split(", ").Select(int.Parse).ToList());

Console.WriteLine(string.Join(", ",lake));