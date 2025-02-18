
using System;

int length = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());

List<int[]> allVectors = new List<int[]>();
int[] vector = new int[length];
List<int> used = new List<int>();

GenerateNonDuplicateVectors(vector, 0, allVectors, used);
Console.WriteLine(string.Join("\n", allVectors.Select(x => string.Join(" ", x))));
Console.WriteLine(allVectors.Count);
void GenerateNonDuplicateVectors(int[] vector, int index, List<int[]> allVectors, List<int> used)
{
    if (index == vector.Length)
    {
        allVectors.Add(vector.ToArray());
        return;
    }
    
    for (int i = 0; i < m; i++)
    {
        if (used.Contains(i))
        {
            continue;
        }
        vector[index] = i;
        used.Add(i);
        GenerateNonDuplicateVectors(vector, index + 1, allVectors, used);
        used.Remove(i);
    }
}
