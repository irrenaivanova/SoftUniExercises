string[] wordsToReplace = Console.ReadLine().Split(", ");
string text = Console.ReadLine();

for (int i = 0; i < wordsToReplace.Length; i++)
{
    text = text.Replace(wordsToReplace[i], new string('*', wordsToReplace[i].Length));
}
Console.WriteLine(text);
