int[] arr = { 5, 2, 9, 1, 5, 6 };
bool changed = false;

for (int i = 0; i < arr.Length; i++)
{
    changed = false;
    for (int j = 0; j < arr.Length - i - 1; j++)
    {
        if (arr[j] > arr[j + 1])
        {
            (arr[j],arr[j+1]) = (arr[j+1],arr[j]);
            changed = true;
        }
    }
    if (!changed)
    {
        break;
    }
}
Console.WriteLine(string.Join(" ",arr));