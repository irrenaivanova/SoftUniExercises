int n = int.Parse(Console.ReadLine());
int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();
List<int> result = new List<int>();

Func<int, int, bool> ifDivider = (x, y) => x % y == 0;
for (int i = 1; i <= n; i++)
{
    bool isDivisable = true;
    for (int j = 0; j < dividers.Length; j++)
	{
		if (!ifDivider(i, dividers[j]))
		{
			isDivisable=false;
            break;
        }
	}
	if (isDivisable)
	{
		result.Add(i);
	}
}
Console.WriteLine(string.Join(" ",result));

