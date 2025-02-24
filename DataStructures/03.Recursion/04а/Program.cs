
int n = int.Parse(Console.ReadLine()!);
int m = int.Parse(Console.ReadLine()!);


List<int[]> results = new List<int[]>();
int[] result = new int[2]; 
FindAll(0);
Console.WriteLine(string.Join("\n", results.Select(x => string.Join(" ",x))));


void FindAll(int index)
{
    if (index == result.Length)
    {
        results.Add(result.ToArray());
        return;
    }

    for (int i = 1; i <= m; i++)
    {
        result[index] = i;
        FindAll(index + 1);
    }
}