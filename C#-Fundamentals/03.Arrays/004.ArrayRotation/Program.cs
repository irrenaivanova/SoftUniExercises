int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n % input.Length; i++)
{
    int firstN = input[0];
    for (int j = 0; j < input.Length - 1; j++)
    {
        input[j] = input[j + 1];
    }
    input[input.Length - 1] = firstN;
}
Console.WriteLine(string.Join(" ", input));