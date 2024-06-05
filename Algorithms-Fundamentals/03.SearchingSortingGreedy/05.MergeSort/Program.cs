
int[] arr = new int[] { 112, 1, 7, 3, 8, 9, 15 };

int[] arrSort = MergeSort(arr,0, arr.Length-1);

Console.WriteLine(string.Join(" ", arrSort));


int[] MergeSort(int[] arr, int start, int end)
{
    if (start == end)
    {
        return new[]{arr[start]};
    }

    int middle = (start + end) / 2;
    
    int[] left = MergeSort(arr, start, middle);
    int[] right = MergeSort(arr, middle+1, end);

    int[] merged = new int [left.Length+right.Length];

    int a = 0;
    int b = 0;
    
    for (int i = 0; i < merged.Length; i++)
    {
        if (a==left.Length)
        {
            merged[i] = right[b];
            b++;
            continue;
        }
        if (b == right.Length)
        {
            merged[i] = left[a];
            a++;
            continue;
        }
        if (left[a] <= right[b])
        {
            merged[i] = left[a];
            a++;
        }
        else
        {
            merged[i] = right[b];
            b++;
        }
    }
    return merged;
}



