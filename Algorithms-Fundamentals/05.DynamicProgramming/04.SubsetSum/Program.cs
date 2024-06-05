int[] nums = new[] { 3, 5, 1, 4, 2 };
int targetSum = 13;

Dictionary<int,int> sums = GetAllPossibleSum(nums);

List<int> result = GetThePath(sums, targetSum);

if (!sums.ContainsKey(targetSum))
{
    Console.WriteLine("NOOOO");
}
else
{
    Console.WriteLine(string.Join(" ", result));
}
Dictionary<int, int> GetAllPossibleSum(int[] nums)
{
    Dictionary<int, int> result = new() { { 0, 0 } };
   
    foreach (var num in nums)
    {
        foreach (var sum in result.Keys.ToArray())
        {
            if (result.ContainsKey(num+sum))
            {
                continue;
            }
            result.Add(num+sum, num);
        }
    }

    return result;
}
List<int> GetThePath(Dictionary<int, int> sums, int targetSum)
{
    List<int> path = new();
    
    while(true)
    {
        if (targetSum==0)
        {
            break;
        }
        int current = sums[targetSum];
        path.Add(current);
        targetSum -= current;
    }

    return path;
}
