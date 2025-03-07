int[] arr = { 5, 2, 9, 1, 5, 6 };

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

    (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
}

Console.WriteLine(string.Join(" ",arr));