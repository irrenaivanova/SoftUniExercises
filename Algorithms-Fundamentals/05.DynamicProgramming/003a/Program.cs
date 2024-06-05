int[] coins = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();
int target = int.Parse(Console.ReadLine());
int count = CountSums(coins, target);
Console.WriteLine(count);
int CountSums(int[] coins, int target)
{
    int[] sums = new int[target+1];
    sums[0] = 1;
    foreach (var coin in coins)
    {
        for (int i = coin; i <= target; i++)
        {
            sums[i] += sums[i - coin];
        }
    }
  return sums[target];
}