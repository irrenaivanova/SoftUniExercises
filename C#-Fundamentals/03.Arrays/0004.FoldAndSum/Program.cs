int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
int k = input.Length / 4;

int[] arr1 = new int[k];
int[] arr2 = new int[2 * k];
int[] arr3 = new int[k];

for (int i = 0; i < 2 * k; i++)
{
    arr2[i] = input[k + i];
}
//Console.WriteLine(string.Join(" ",arr2));

for (int i = 0; i < k; i++)
{
    arr1[i] = input[k - i - 1];
}
//Console.WriteLine(string.Join(" ", arr1));

for (int i = 0; i < k; i++)
{
    arr3[i] = input[4 * k - i - 1];
}
//Console.WriteLine(string.Join(" ", arr3));

int[] final = new int[2 * k];
for (int i = 0; i < 2 * k; i++)
{
    if (i < k)
        final[i] = arr1[i] + arr2[i];
    else
        final[i] = arr2[i] + arr3[i - k];
}
Console.WriteLine(string.Join(" ", final));