int n = int.Parse(Console.ReadLine());

Dictionary<string, List<string>> list = new Dictionary<string, List<string>>();

for (int i = 0; i < n; i++)
{
    string word1 = Console.ReadLine();
    string word2 = Console.ReadLine();

    if (!list.ContainsKey(word1))
    {
        list.Add(word1, new List<string>());
        list[word1].Add(word2);
    }
    else
    {
        list[word1].Add(word2);
    }
}

foreach (var item in list)
{
    Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
}