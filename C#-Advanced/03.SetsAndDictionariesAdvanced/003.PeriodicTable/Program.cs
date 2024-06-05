int n = int.Parse(Console.ReadLine());
SortedSet<string> list = new SortedSet<string>();

for (int i = 0; i < n; i++)
{
    string[] elements = Console.ReadLine().Split();
    for (int j = 0; j < elements.Length; j++)
    {
        list.Add(elements[j]);
    }
}
Console.WriteLine(string.Join(" ", list));