using _03.Strings2;
using System.Text.RegularExpressions;
var text = ")(a+b))";
var validator = new ParenthesesValidator(text);
Console.WriteLine(validator.Validate());

var text2 = "We are living in a <upcase>yellow submarine</upcase>. We don't\r\nhave <upcase>anything</upcase> else.";
var upper = new UpperCaseMaker();
Console.WriteLine(upper.Run(text2)); 

string input = "ccbcb";
char[] result = new char[20];
for (int i = 0; i < 20; i++)
{
    if (i < input.Length)
    {
        result[i] = input[i];
        continue;
    }
    result[i] = '*';
}
Console.WriteLine(result);

string text3 = "Microsoft announced its next generation C# compiler today. It\r\nuses advanced parser and special optimizer for the Microsoft CLR.";
var pattern = @"C#|Microsoft|CLR";
string result3 = Regex.Replace(text3,pattern,match => new string('*',match.Length));
Console.WriteLine(result3);

string text4 = "aaaaabbbbbcdddeeeedssaa";
string pattern4 = @"(\w)\1+";
string result4 = Regex.Replace(text4, pattern4, match => match.Value[0].ToString());
Console.WriteLine(result4);

int number = 17;
bool isPrime = true;

for (int i = 2; i < Math.Sqrt(number); i++)
{
    if(number%i==0)
    {
        isPrime = false;
        break;
    }
}
Console.WriteLine(isPrime);
