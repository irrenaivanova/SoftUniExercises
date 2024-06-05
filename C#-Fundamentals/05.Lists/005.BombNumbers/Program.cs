List<int> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int bomb = input[0];
int power = input[1];


for (int i = 0; i < list.Count; i++)
{
    if (list[i] == bomb)
    {
        int start = Math.Max(0, i - power);
        int end = Math.Min(list.Count - 1, i + power);
        int count = end - start + 1;
        for (int j = 0; j < count; j++)
        {
            list.RemoveAt(start);
        }
        i = Math.Max((i - count), 0);
    }

}
int sum = 0;
for (int i = 0; i < list.Count; i++)
{
    sum += list[i];
}
Console.WriteLine(sum);
//Console.WriteLine(string.Join(" ",list));