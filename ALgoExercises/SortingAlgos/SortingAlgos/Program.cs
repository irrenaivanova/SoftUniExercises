int[] arr = { 1, 3, 5, 7, 9, 11, 15 };
int target = 20;

int left = 0;
int right = arr.Length - 1;

while (left <= right)
{
    int middle = (left + right)/2;
    
    if (arr[middle] == target)
    {
        Console.WriteLine("true");
        return;
    }

    else if (arr[middle] < target)
    {
        left = middle + 1;
    }

    else if (arr[middle] > target)
    {
        right = middle - 1;
    }
}
Console.WriteLine("false");

