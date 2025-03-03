using System.Text;

string input = Console.ReadLine()!;
int n = int.Parse(Console.ReadLine())!;

StringBuilder sb = new StringBuilder();
foreach (var c in input)
{
    sb.Append((char)(c - n));
}
Console.WriteLine(sb.ToString().Trim());
