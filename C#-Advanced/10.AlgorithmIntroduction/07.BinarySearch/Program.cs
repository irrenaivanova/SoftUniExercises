int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
int element = int.Parse(Console.ReadLine());

int index = BinarySearch(arr, element, 0, arr.Length-1);

int BinarySearch(int[] arr, int element, int start, int end)
{
    int middle = (start+end) / 2;
    if (start>end)
    {
        return -1;
    }

    if (arr[middle] == element)
    {
        return middle;
    }
    else if (arr[middle] > element)
    { 
        return BinarySearch(arr,element,0,middle-1);
    }
    else
    {
        return BinarySearch(arr, element, middle+1, end);
    }
}

Console.WriteLine(index);

