using System.Data.SqlTypes;
using System.Text;

string input = Console.ReadLine();
string theLongest = string.Empty;
int theLongestcount = 0;

for (int i = 0; i < input.Length; i++)
{
    for (int m = input.Length - 1; m >= 0; m--)
    {
        string substring = input.Substring(i, m - i + 1);
        StringBuilder reversed = new StringBuilder();

        for (int j = substring.Length - 1; j >= 0; j--)
        {
            reversed.Append(substring[j]);
        }

        if (substring == reversed.ToString())
        {
            if (substring.Length > theLongestcount)
            {
                theLongest = substring;
                theLongestcount = substring.Length;
            }
            break;
        }
    }
}
Console.WriteLine(theLongestcount);
Console.WriteLine(theLongest);
