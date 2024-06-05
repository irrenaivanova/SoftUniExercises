int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
bool isBigger = false;
for (int i = 0; i < arr.Length - 1; i++)
{
    for (int j = i + 1; j < arr.Length; j++)
    {
        if (arr[i] > arr[j])
            isBigger = true;
        else
            isBigger = false;
        break;
    }
    if (isBigger)
        Console.Write(arr[i] + " ");
}
Console.Write(arr[arr.Length - 1]);