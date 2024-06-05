int[] arr = new int[] { 1, 3, 7, 8, 9, 15, 112 };

int number = 8;
int index = BinarySearch(arr,0,arr.Length-1, number);
Console.WriteLine(index);


int BinarySearch(int[] arr,int start,int end, int number)
{
    int middle = (start + end) / 2;
    
    if (arr[middle]==number)
    {
        return middle;
    }

    if (arr[middle]<number) 
    {
        return BinarySearch(arr, middle+1, end, number);
    }
    else
    {
        return BinarySearch(arr, 0, middle-1, number);
    }
}

