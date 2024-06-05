List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
List<Sum> sums = new List<Sum>();

bool ifStart = false;

for (int i = 0; i < numbers.Count; i++)
{
    if (numbers[i] >= 0)
    {
        if (!ifStart)
        {
            ifStart = true;
            Sum newSum = new Sum();
            newSum.Index = i;
            newSum.Numbers.Add(numbers[i]);
            sums.Add(newSum);
        }
        else
        {
            sums.Last().Numbers.Add(numbers[i]);
        }
    }
    else
    {
        if (sums.Count > 0)
        {
            sums.Last().End = numbers[i];
        }
        ifStart = false;
    }
}
for (int i = 0; i < sums.Count-1; i++)
{
    if (sums[i].Numbers.Sum() > Math.Abs(sums[i].End))
    {
        sums[i].Numbers.Add(sums[i].End);
        sums[i].Numbers.AddRange(sums[i + 1].Numbers);
        sums[i].End = sums[i + 1].End;
        sums.RemoveAt(i + 1);
    }
}


if (sums.Count==0)
{
    int max = numbers.Max();
    int index = numbers.IndexOf(max);
    Console.WriteLine($"{max} {index} {index}");
    return;
}
sums = sums.OrderByDescending(x => x.Numbers.Sum())
    .ThenByDescending(x => x.Numbers.Count())
    .ThenBy(x => x.Index)
    .ToList();

Console.WriteLine($"{sums.First().Numbers.Sum()} {sums.First().Index} {sums.First().Index+sums.First().Numbers.Count - 1}");

class Sum
{
    public int Index;
    public List<int> Numbers= new();
    public int End;
}



//if (Math.Abs(numbers[i]) < sums.Last().Numbers.Sum())
//{
//    sums.Last().Numbers.Add(numbers[i]);
//}
//else
//{
//    ifStart = false;
//}