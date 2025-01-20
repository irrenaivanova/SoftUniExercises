Stack<int>items = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
int rack = int.Parse(Console.ReadLine());
int count = 1;

int leftCap = rack;
while(items.Count > 0)
{
    if (leftCap - items.Peek()>=0)
    {
        leftCap -= items.Pop();
    }
    else
    {
        count++;
        leftCap = rack;
    }
}
Console.WriteLine(count);