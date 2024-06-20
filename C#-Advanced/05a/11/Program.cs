//int n = int.Parse(Console.ReadLine());
//List<string> input = Console.ReadLine().Split().ToList();
//string result = input.Where(x =>
//{
//	int sum = 0;
//	foreach (var y in x)
//	{
//		sum += y;
//	}
//	return sum>=n;
//}).FirstOrDefault();

//Console.WriteLine(result);

int n = int.Parse(Console.ReadLine());
List<string> input = Console.ReadLine().Split().ToList();
string result = input.FirstOrDefault(x => x.Sum(y => y)>=n);
Console.WriteLine(result);