int[] nums = new[] { 3, 5, 2 };
int target = 17;

bool[] result = new bool[target+1];
result[0] = true;

for (int i = 0; i < result.Length; i++)
{
	if (result[i])
	{
		foreach (var num in nums)
		{
			if (i+num>=result.Length || result[i+num])
			{
				continue;
			}
			result[i + num] = true;
		}
	}
}

List<int> path = new List<int>();

while (target > 0)
{
	foreach (var num in nums)
	{
		if (target - num >= 0)
		{
			target -= num;
			path.Add(num);
		}
	}
}
Console.WriteLine(string.Join(" ", path));
Console.WriteLine(result[target]);

