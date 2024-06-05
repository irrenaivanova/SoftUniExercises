int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
int maxCount = 0;
int count = 0;
int num = 0;
bool isFound = false;
for (int i = arr.Length - 1; i > 0; i--)
{
    if (arr[i] == arr[i - 1])
    {
        isFound = true;
        count++;
        if (count >= maxCount)
        {
            maxCount = count;
            num = arr[i];
        }
    }
    else
        count = 0;
}
for (int i = 1; i <= maxCount + 1; i++)
{
    Console.Write($"{num} ");
}
if (!isFound)
    Console.WriteLine(arr[0]);