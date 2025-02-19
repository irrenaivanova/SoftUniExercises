using System.Text;

string first = "abc";
string second = first;
second += "something";

Console.WriteLine(first);
Console.WriteLine(second);

List<int> indexes = new List<int>();
string quote = "The main intent of the \"Intro C#\"" +
" book is to introduce the C# programming to newbies.";

string keyWord = "C#";

int index = quote.IndexOf(keyWord);
while (index != -1)
{
    indexes.Add(index);
    index = quote.IndexOf(keyWord, index+keyWord.Length);
}
Console.WriteLine(string.Join(", ",indexes));

StringBuilder sb = new StringBuilder();
for (int i = 0; i < 100; i++)
{
    sb.Append(i.ToString());
}
Console.WriteLine(sb.Capacity);
Console.WriteLine(sb.Length);

StringBuilder sb2 = new StringBuilder(180);
for (int i = 0; i < 100; i++)
{
    sb2.Append(i.ToString());
}
Console.WriteLine(sb2.Capacity);
Console.WriteLine(sb2.Length);