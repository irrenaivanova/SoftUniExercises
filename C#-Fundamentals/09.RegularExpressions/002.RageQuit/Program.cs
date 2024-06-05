using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

string input = Console.ReadLine().ToUpper();
//string pattern1 = @"[^0-9]";
string pattern2 = @"[^0-9]+[0-9]{1,2}";

//StringBuilder stringSymbols = new StringBuilder();
//MatchCollection matches = Regex.Matches(input, pattern1);
//foreach (Match match in matches)
//{
//    stringSymbols.Append(match.Value);
//}
//string distinctSymbols = new String(stringSymbols.ToString().Distinct().ToArray());

StringBuilder final = new StringBuilder();
MatchCollection matches2 = Regex.Matches(input, pattern2);
foreach (Match match in matches2)
{
    StringBuilder text = new StringBuilder();
    StringBuilder number = new StringBuilder();
    for (int i = 0; i < match.Length; i++)
    {
        if (Char.IsDigit(match.Value[i]))
            number.Append(match.Value[i]);
        else
            text.Append(match.Value[i]);
    }
    int numberM = int.Parse(number.ToString());
    for (int i = 0; i < numberM; i++)
    {
        final.Append(text);
    }
}
int symbolCount = final.ToString().Distinct().Count();
Console.WriteLine($"Unique symbols used: {symbolCount}");
Console.WriteLine(final);
//Console.WriteLine(distinctSymbols);