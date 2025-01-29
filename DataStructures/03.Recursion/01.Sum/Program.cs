
int[] array = new int[] { 1, 2, 5, 2, 3, 8, 9 };
int sum = array.Sum();
int sum2 = SumTheMatrix(array, 0);

Console.WriteLine(sum);
Console.WriteLine(sum2);

 int SumTheMatrix(int[] array, int index)
{
    if (index == array.Length)
    {
        return 0;
    }

    return array[index] + SumTheMatrix(array, index + 1);
}
