//моя имплементация, не е правилната

List<int> arr = new () { 112, 1, 7, 3, 8, 9, 15 };

for (int i = 0; i < arr.Count; i++)
{
	for (int j = 0; j < i; j++)
	{
		if (i==1 && arr[i] < arr[j])
		{
			int temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;
			continue;
		}
		if (arr[i] > arr[j] && arr[i] <= arr[j+1])
		{
			arr.Insert(j+1, arr[i]);
			arr.RemoveAt(i+1);
		}
	}
}

Console.WriteLine(string.Join(" ", arr));
