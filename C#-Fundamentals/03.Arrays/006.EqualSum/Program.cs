int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
bool isFound = false;

for (int i = 0; i < arr.Length; i++)
{
    int sumL = 0;
    int sumR = 0;

    for (int j = 0; j < i; j++)
    {
        sumL += arr[j];
    }
    for (int j = i + 1; j < arr.Length; j++)
    {
        sumR += arr[j];
    }
    if (i == 0)
        sumL = 0;
    if (i == arr.Length - 1)
        sumR = 0;
    if (sumL == sumR)
    {
        Console.WriteLine(i);
        isFound = true;
        break;
    }
}
if (!isFound)
    Console.WriteLine("no");