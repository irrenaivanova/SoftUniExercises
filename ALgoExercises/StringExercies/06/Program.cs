using System.Text;

string input = Console.ReadLine()!;
StringBuilder sb = new StringBuilder();

sb.Append(input[0]);
for (int i = 1; i < input.Length; i++)
{
    if (input[i] == sb[sb.Length - 1])
    {
        continue;
    }
    sb.Append(input[i]);
}
Console.WriteLine(sb.ToString().Trim());