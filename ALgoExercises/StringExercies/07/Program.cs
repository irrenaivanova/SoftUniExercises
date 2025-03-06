using System.Text;

string input = Console.ReadLine()!;
StringBuilder sb = new StringBuilder();
int strength = 0;

for (int i = 0; i < input.Length; i++)
{
    if (strength > 0)
    {
        if (input[i] == '>')
        {
            sb.Append(input[i]);
            strength += input[i + 1] - '0';
            continue;
        }
        strength--;
        continue;
    }
    if (input[i] != '>')
    {
        sb.Append(input[i]);
        continue;
    }

    // if we are out of array ?
    sb.Append(input[i]);
    strength = input[i + 1] - '0';
}
Console.WriteLine(sb.ToString().Trim());