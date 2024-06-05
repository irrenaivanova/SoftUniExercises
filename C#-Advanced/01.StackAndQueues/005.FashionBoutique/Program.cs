Stack<int> clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
int capacity = int.Parse(Console.ReadLine());
int leftCapacity = capacity;
int racks = 1;
while (clothes.Count > 0)
{
    if (clothes.Peek() <= leftCapacity)
    {
        leftCapacity -= clothes.Pop();
    }
    else
    {
        racks++;
        leftCapacity = capacity;
    }
}
Console.WriteLine(racks);
