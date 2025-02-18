int length = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());

List<int[]> allVectors = new List<int[]>();
int[] vector =new int[length];

GenerateAllVectors(vector, 0);
Console.WriteLine(string.Join("\n", allVectors.Select(x => string.Join(" ", x))));
Console.WriteLine(allVectors.Count);

void GenerateAllVectors(int[] vector, int index)
{
    if(index == vector.Length)
    {
        allVectors.Add(vector.ToArray());
        return;
    }
    for (int i = 0; i < m; i++)
    {
        vector[index] = i;
        GenerateAllVectors(vector, index + 1);
    }
}

