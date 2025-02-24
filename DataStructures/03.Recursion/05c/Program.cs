string[] words = Console.ReadLine()!.Split(", ");

List<string[]> results = new List<string[]>();

for (int i = 1; i <= words.Length; i++)
{
    string[] result = new string[i];
    FindAllWords(0, 0, result);
}



Console.WriteLine(string.Join("\n", results.Select(x => string.Join(" ", x))));


void FindAllWords(int index, int startWords, string[] result)
{
    if (index == result.Length)
    {
        results.Add(result.ToArray());
        return;
    }

    for (int i = startWords; i < words.Length; i++)
    {
        result[index] = words[i];
        FindAllWords(index + 1, i + 1, result);
    }
}