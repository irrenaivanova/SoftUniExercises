int[] arr = new int[] { 112, 1, 7, 3, 8, 9, 15 };

for (int i = 0; i < arr.Length; i++)
{
	for (int j = 0; j < arr.Length-i-1; j++)
	{
		if (arr[j] > arr[j+1])
		{
			int temp = arr[j];
			arr[j] = arr[j+1];
			arr[j+1] = temp;
		}
	}
}

Console.WriteLine(string.Join(" ", arr));
