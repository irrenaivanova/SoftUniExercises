using System.Linq;

int[] presents = Console.ReadLine().Split().Select(int.Parse).ToArray();
int sumTotal = presents.Sum();
int targetSum = sumTotal / 2;

SortedDictionary<int, int> allSums = GetAllSums(presents);

int sumAlan = 0;
foreach (var sum in allSums)
{
    if (sum.Key-targetSum<=0)
    {
        sumAlan = sum.Key;
        break;
    }
}

List<int> presentsAlan = GetThePath(allSums, sumAlan);

List<int> GetThePath(SortedDictionary<int, int> allSums, int sumAlan)
{
    List<int> presents = new List<int>();

    while (sumAlan > 0)
    {
        int currPresent = allSums[sumAlan];
        presents.Add(currPresent);
        sumAlan -= currPresent;
    }
    return presents;
}
int sumALan = presentsAlan.Sum();
int sumBob = sumTotal - sumALan;

Console.WriteLine($"Difference: {sumBob-sumALan}");
Console.WriteLine($"Alan: {sumALan} Bob: {sumBob}");
Console.WriteLine($"Alan takes: {string.Join(" ",presentsAlan)}");
Console.WriteLine("Bob takes the rest.");


SortedDictionary<int, int> GetAllSums(int[] presents)
{
    SortedDictionary<int, int> sums = new(Comparer<int>.Create((x, y) => y.CompareTo(x))) { { 0, 0 } };

    foreach (var present in presents)
    {
        foreach (var sum in sums.Keys.ToArray())
        {
            if (sums.ContainsKey(sum + present))
            {
                continue;
            }

            sums.Add(sum + present, present);
        }
    }
    return sums;
}