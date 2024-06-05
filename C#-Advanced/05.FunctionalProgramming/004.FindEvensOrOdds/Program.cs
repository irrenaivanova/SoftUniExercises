int[] borders = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int start = borders[0];
int end = borders[1];
string filterWord = Console.ReadLine();

Predicate<int> filter = GetFilter(filterWord);
List<int> result = new List<int>();

for (int i = start; i <= end; i++)
{
    result.Add(i);
}
result= result.Where(x => filter(x)).ToList();
Console.WriteLine(string.Join(" ",result));
Predicate<int> GetFilter(string filterWord)
{
    if (filterWord=="odd")
    {
        return x => x % 2 != 0;
    }
    else
        return x => x % 2 == 0;
}

