string[] words = Console.ReadLine()!.Split(", ");
int k = int.Parse(Console.ReadLine()!);
List<string[]> results = new List<string[]>();
string[] result = new string[k];
HashSet<string> used = new HashSet<string>();

FindAllWords(0,0);

Console.WriteLine(string.Join("\n", results.Select(x => string.Join(" ", x))));


void FindAllWords(int index, int startWords)
{
    if (index == k)
    {
        results.Add(result.ToArray());
        return;
    }

    for (int i = startWords; i < words.Length; i++)
    {
        result[index] = words[i];
        FindAllWords(index + 1, i + 1);
    }
}