using System.Collections.Generic;

int[] array1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[] array2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
int minNumber = 0;
int maxNumber = 0;

int length1 = array1.Length;
int length2 = array2.Length;

if (length1 > length2)
{
    minNumber = Math.Min(array1[length1 - 1], array1[length1 - 2]);
    maxNumber = Math.Max(array1[length1 - 1], array1[length1 - 2]);
}
else
{
    minNumber = Math.Min(array2[0], array2[1]);
    maxNumber = Math.Max(array2[0], array2[1]);
}

List<int> allNumbers = new List<int>();
allNumbers.AddRange(array1);
allNumbers.AddRange(array2);

for (int i = 0; i < allNumbers.Count; i++)
{
    if (allNumbers[i] <= minNumber || allNumbers[i] >= maxNumber)
    {
        allNumbers.RemoveAt(i);
        i--;
    }
}

for (int i = 0; i < allNumbers.Count; i++)
{
    int min = i;
    for (int j = i; j < allNumbers.Count; j++)
    {
        if (allNumbers[j] <= allNumbers[min])
            min = j;
    }
    int temp = allNumbers[min];
    allNumbers[min] = allNumbers[i];
    allNumbers[i] = temp;
}

Console.WriteLine(string.Join(" ", allNumbers));


