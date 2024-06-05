int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[,] matrix = new int[nums.Length + 1, nums.Length + 1];

for (int i = 0; i < nums.Length; i++)
{
    matrix[i, 0] = 0;
}
for (int i = 0; i < nums.Length; i++)
{
    matrix[0, i] = 0;
}

for (int i = 1; i < nums.Length+1; i++)
{
    for (int j = 1; j < nums.Length+1; j++)
    {
        if (nums[j-1] == i)
        {
            matrix[i,j] = matrix[i-1,j-1]+1;
        }
        else
        {
            matrix[i, j] = Math.Max(matrix[i-1, j], matrix[i, j-1]);
        }
    }
}
Console.WriteLine(matrix[nums.Length,nums.Length]);