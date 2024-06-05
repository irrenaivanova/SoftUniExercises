
int[] arr = new int[] { 112, 1, 7, 3, 8, 9, 15 };

for (int i = 0; i < arr.Length; i++)
{
    int minIndex = i;
	
	for (int j = i+1; j < arr.Length; j++)
	{
		if (arr[j] < arr[minIndex])
		{
			minIndex = j;
		}
	}

    int temp = arr[minIndex];
    arr[minIndex] = arr[i];
    arr[i] = temp;
}
Console.WriteLine(string.Join(" ",arr));

