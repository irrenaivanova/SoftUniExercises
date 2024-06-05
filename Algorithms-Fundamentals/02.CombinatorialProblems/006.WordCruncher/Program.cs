using System;
using System.CodeDom.Compiler;

string[] wordsinput = Console.ReadLine().Split(", ");
string finalWord = Console.ReadLine();

List<Word> words = new List<Word>();
List<int> indexes = new List<int>();

foreach (var word in wordsinput)
{
    if (!words.Select(x => x.Name).Contains(word))
    {
        words.Add(new Word(word, 0));
    }
    words.First(x => x.Name == word).Count++;
    IndexOfTheWOrd(word, 0);
    words.First(x => x.Name == word).PlacesInWord.AddRange(indexes);
    indexes.Clear();
}

List<string> combination = new();

GenerateCombinations(0);

void GenerateCombinations(int start)
{
    if(start>=finalWord.Length)
    {
        Console.WriteLine(string.Join(" ",combination));
        return;
    }

    foreach (var word in words.Where(x => x.PlacesInWord.Contains(start)))
    {
        if (word.Count > 0)
        {
            combination.Add(word.Name);
            word.Count--;
            GenerateCombinations(start+word.Name.Length);
            word.Count++;
            combination.Remove(word.Name);
        }
    }
}

void IndexOfTheWOrd(string word, int start)
{   
    int index = finalWord.IndexOf(word, start);
    if (index==-1 || start>=finalWord.Length)
    {
        return;
    }
    else
        indexes.Add(index);

    IndexOfTheWOrd(word, index + word.Length);
}

class Word
{
    public Word(string name, int count)
    {
        Name = name;
        Count = count;
        List<int> PlacesInWord = new();
    }
    public string Name { get; set; }
    public int Count { get; set; }
    public List<int> PlacesInWord { get; set; } = new();
}