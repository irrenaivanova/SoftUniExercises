using System.Collections;

int end = int.Parse(Console.ReadLine());
int[] ints = Console.ReadLine().Split().Select(int.Parse).ToArray();

Func<int, bool> func = (int x) =>
{
	foreach (var number in ints)
	{
		if (x % number != 0)
		{
			return false;
		}
	}
	return true;
};
Console.WriteLine(string.Join(" ",Enumerable.Range(1,end).Where(func)));
