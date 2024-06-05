int[] arr = new int[] { 1,2,3,4,5,6,7 };
int[] evenNumbers = Where(arr,x => x%2==0);

Console.WriteLine(string.Join(" ", evenNumbers));

int[] Where(int[] arr, Func<int, bool> filter)
{
	List<int> result = new List<int>();
	foreach (int number in arr)
	{
		if (filter(number))
		{ result.Add(number); }
	}
	return result.ToArray();
}

