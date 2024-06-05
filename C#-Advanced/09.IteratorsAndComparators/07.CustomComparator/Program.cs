List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

numbers.Sort(new CostumComperator());
Console.WriteLine(string.Join(" ",numbers));


public class CostumComperator : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if (x % 2 == 0 && y % 2 != 0)
        {
            return -1;
        }
        if (x % 2 != 0 && y % 2 == 0)
        {
            return 1;
        }
        return x.CompareTo(y);
    }
}