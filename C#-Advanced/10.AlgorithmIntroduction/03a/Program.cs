namespace SumOfCoins
{
    using System.Collections.Generic;
    using System.Diagnostics;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] coins = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int targetSum = int.Parse(Console.ReadLine());
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Dictionary<int, int> result = ChooseCoins(coins, targetSum);
            if (result == null)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine($"Number of coins to take: {result.Values.Sum()}");
                foreach (var coin in result)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
            stopwatch.Stop();
            //Console.WriteLine($"It takes {stopwatch.ElapsedMilliseconds}");
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            Dictionary<int, int> coinsCount = new();

            coins = coins.OrderByDescending(x => x).ToList();
            for (int i = 0; i < coins.Count; i++)
            {
                if (targetSum >= coins[i])
                {
                    int count = targetSum / coins[i];
                    targetSum -= coins[i] * count;
                    coinsCount.Add(coins[i], count);
                }
                if (targetSum == 0)
                {
                    break;
                }
            }
            if (targetSum > 0)
            {
                return coinsCount = null;
            }
            return coinsCount;
        }
    }
}