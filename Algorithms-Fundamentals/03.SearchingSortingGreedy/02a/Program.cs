
int[] arr = new int[] { 112, 1, 7, 3, 8, 9, 15 };

for (int i = 1; i < arr.Length; i++)
{
	for (int j = i; j > 0; j--)
	{
		if (arr[j] < arr[j - 1])
		{
			int temp = arr[j];
			arr[j] = arr[j - 1];
			arr[j - 1] = temp;
		}
	}
}
Console.WriteLine(string.Join(" ", arr));

