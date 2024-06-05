//Мои разсъждения неуспешни, виж следващото решение

int[] coinsWithoutRep = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();
int targetSum = int.Parse(Console.ReadLine());

List<int> coins = new();

int currSum = targetSum;

for (int i = 0; i < coinsWithoutRep.Length; i++)
{
    int currCoin= coinsWithoutRep[i];
    
    if (currSum - currCoin>0)
    {
        currSum -= coinsWithoutRep[i];
        coins.Add(currCoin);
        i--;
    }
    else
    {
        if (currSum - currCoin == 0)
        {
            coins.Add(currCoin);
        }
        currSum = targetSum;
    }
}

int count = 0;

HashSet<int> sums = GetAllSum(coins);
Console.WriteLine(count);

HashSet<int> GetAllSum(List<int> coins)
{
    HashSet<int> sums = new HashSet<int>() ;
    
    foreach (var coin in coins)
    {
        foreach (var sum in sums.ToArray())
        {
            int currSum = sum + coin;
            
            if (currSum==targetSum && sum!=0 && coin!=0)
            {
                count++;
            }
            if (currSum>targetSum)
            {
                continue;
            }
            sums.Add(currSum);
        }
    }
    return sums;
}