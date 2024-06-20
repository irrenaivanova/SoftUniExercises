List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
int n = int.Parse(Console.ReadLine());

Console.WriteLine(string.Join(" ",input.Where(x=>x%n!=0).Reverse()));