var list = new CoolList<int>();
for (int i = 0; i < 15; i++)
{
    list.Add(i);
}

list.Remove(5);
list.RemoveAt(2);
Console.WriteLine($"Count: {list.Count}");
for (int i = 0;i < list.Count;i++)
{
    Console.Write($"{list[i]} ");
}
Console.WriteLine();   
Console.WriteLine(string.Join(" ", list));
