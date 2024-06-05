List<int> list1 = Console.ReadLine().Split().Select(int.Parse).ToList();
List<int> list2 = Console.ReadLine().Split().Select(int.Parse).ToList();

List<int> list3 = new List<int>();

int maxCount = Math.Max(list1.Count, list2.Count);

for (int i = 0; i < maxCount; i++)
{
    if (list1.Count > i)
        list3.Add(list1[i]);

    if (list2.Count > i)
        list3.Add(list2[i]);
}

Console.WriteLine(string.Join(" ", list3));