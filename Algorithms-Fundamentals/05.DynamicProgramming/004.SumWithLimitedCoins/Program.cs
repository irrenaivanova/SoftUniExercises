
List<int> coins = Console.ReadLine().Split().Select(int.Parse).ToList();
int targetSum = int.Parse(Console.ReadLine());
int count = 0;

HashSet<int> sums = GetAllSum(coins);
Console.WriteLine(count);

HashSet<int> GetAllSum(List<int> coins)
{
    HashSet<int> sums = new HashSet<int>() {0};

    foreach (var coin in coins)
    {
        foreach (var sum in sums.ToArray())
        {
            int currSum = sum + coin;

            if (currSum == targetSum)
            {
                count++;
            }
            if (currSum > targetSum)
            {
                continue;
            }
            sums.Add(currSum);
        }
    }
    return sums;
}