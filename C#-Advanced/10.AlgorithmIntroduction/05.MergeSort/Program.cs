using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

int n = 100000000;
//int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

int[] array = new int[n];
for (int i = 0; i < n; i++)
{
    array[i] = n - i-1;
}

int[] array2 = new int[array.Length];
int[] array3 = new int[array.Length];
int[] array4 = new int[array.Length];

Array.Copy(array,array2,array.Length);
Array.Copy(array, array3, array.Length);
Array.Copy(array, array4, array.Length);

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
//SelectionSort(array2);
//Console.WriteLine(string.Join(" ", SelectionSort(array2)));
stopwatch.Stop();
Console.WriteLine($"SelectionSort: {stopwatch.ElapsedMilliseconds}");

stopwatch.Reset();
stopwatch.Start();
//BubbleSort(array3);
//Console.WriteLine(string.Join(" ", BubbleSort(array3)));
stopwatch.Stop();
Console.WriteLine($"BubbleSort: {stopwatch.ElapsedMilliseconds}");

stopwatch.Reset();
stopwatch.Start();
MergeSort(array4, 0, array4.Length - 1);
//Console.WriteLine(string.Join(" ", MergeSort(array4, 0, array4.Length - 1)));
stopwatch.Stop();
Console.WriteLine($"MergeSort: {stopwatch.ElapsedMilliseconds}");


int[] SelectionSort(int[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        int min = i;

        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[j] < array[min])
            {
                min = j;
            }
        }
        int temp = array[min];
        array[min] = array[i];
        array[i] = temp;
    }
    return array;
}



int[] BubbleSort(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = 0; j < array.Length-1-i; j++)
        {
            if (array[j+1] < array[j])
            {
                int temp = array[j];
                array[j] = array[j+1];
                array[j+1] = temp;
            }
        }
    }
    return array;
}



int[] MergeSort(int[] array, int start, int end)
{
    int middle = (start + end) / 2;
    if (start==end)
    {
        return new int[] { array[start] };

    }

    int[] left = MergeSort(array, start, middle);
    int[] right = MergeSort(array, middle+1, end);

    int[] newArray = new int[left.Length + right.Length];
    int indexLeft = 0;
    int indexRight = 0;

    for (int i = 0; i < newArray.Length; i++)
    {
        if (indexLeft == left.Length)
        {
            newArray[i] = right[indexRight];
            indexRight++;
        }
        else if (indexRight == right.Length)
        {
            newArray[i] = left[indexLeft];
            indexLeft++;
        }

        else if (left[indexLeft] <= right[indexRight])
        {
            newArray[i] = left[indexLeft];
            indexLeft++;
        }
        else if (left[indexLeft] > right[indexRight])
        {
            newArray[i] = right[indexRight];
            indexRight++;
        }
    }
   return newArray;
}