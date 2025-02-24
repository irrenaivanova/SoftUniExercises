
string[] words = Console.ReadLine()!.Split(", ");
int k = int.Parse(Console.ReadLine()!);
List<string[]> results = new List<string[]>();
string[] result = new string[k];
HashSet<string> used = new HashSet<string>();

FindAllWords(0);

Console.WriteLine(string.Join("\n",results.Select(x => string.Join(" ",x))));



void FindAllWords(int index)
{
    if (index == k)
    {
        results.Add(result.ToArray());
        return;
    }

    for (int i = 0; i < words.Length; i++)
    {
        if (!used.Contains(words[i]))
        {
            result[index] = words[i];
            used.Add(words[i]);
            FindAllWords(index + 1);

            used.Remove(words[i]);

        }
    }
}