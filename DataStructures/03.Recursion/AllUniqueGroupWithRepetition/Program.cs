int length = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());

List<int[]> allVectors = new List<int[]>();
int[] vector = new int[length];

AllUniqueGroupsWithRepetition(vector, 0, 0, allVectors);
Console.WriteLine(string.Join("\n", allVectors.Select(x => string.Join(" ", x))));
Console.WriteLine(allVectors.Count);
void AllUniqueGroupsWithRepetition(int[] vector, int index, int start, List<int[]> allVectors)
{
    if (index == vector.Length)
    {
        allVectors.Add(vector.ToArray());
        return;
    }

    for (int i = start; i < m; i++)
    {
        vector[index] = i;
        AllUniqueGroupsWithRepetition(vector, index + 1, i , allVectors);
    }
}