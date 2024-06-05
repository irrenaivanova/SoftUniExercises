using System.Text;
using System.Text.RegularExpressions;

int n = int.Parse(Console.ReadLine());
List<string> kids = new List<string>();

while (true)
{
    string input = Console.ReadLine();
    if (input == "end")
        break;

    StringBuilder kidInput = new StringBuilder();
    for (int i = 0; i < input.Length; i++)
    {
        kidInput.Append((char)(input[i] - n));
    }

    string pattern = @"@([A-Za-z]+)([^@\-!:>]+)*!([GN])!";
    Match kid = Regex.Match(kidInput.ToString(), pattern);
    string name = kid.Groups[1].Value;
    string ifGood = kid.Groups[3].Value;
    if (ifGood == "G")
    {
        kids.Add(name);
    }
}
Console.WriteLine(string.Join("\n", kids));
