List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
int sum = 0;

while (true)
{
    if (list.Count == 0)
        break;
    int index = int.Parse(Console.ReadLine());
    int numberAtIndex = 0;
    if (index < 0)
    {
        numberAtIndex = list[0];
        list[0] = list[list.Count - 1];
    }
    else if (index > list.Count - 1)
    {
        numberAtIndex = list[list.Count - 1];
        list[list.Count - 1] = list[0];
    }
    else
    {
        numberAtIndex = list[index];
        list.RemoveAt(index);
    }

    sum += numberAtIndex;

    for (int i = 0; i < list.Count; i++)
    {
        if (list[i] <= numberAtIndex)
        {
            list[i] += numberAtIndex;
        }
        else
        {
            list[i] -= numberAtIndex;
        }
    }
}
Console.WriteLine(sum);
