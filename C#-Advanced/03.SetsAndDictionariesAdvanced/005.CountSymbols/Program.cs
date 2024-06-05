string input = Console.ReadLine();
SortedDictionary<char, int> occurances = new SortedDictionary<char, int>();

foreach (char char_ in input)
{
    if (!occurances.ContainsKey(char_))
    {
        occurances.Add(char_, 0);
    }
    occurances[char_]++;
}
foreach (var occ in occurances)
{
    Console.WriteLine($"{occ.Key}: {occ.Value} time/s");
}