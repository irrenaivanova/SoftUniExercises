using System.Text;

string number = Console.ReadLine()!;
int multiplyer = int.Parse(Console.ReadLine()!);

StringBuilder sb = new StringBuilder();
int remainder = 0;

for (int i = number.Length - 1; i >= 0; i--)
{
    int digit = int.Parse(number[i].ToString());
    int product = multiplyer * digit + remainder;
    remainder = product / 10;
    int endNumber = product % 10;
    sb.Append(endNumber);
}
if (remainder > 0)
{
    sb.Append(remainder);
}    

StringBuilder sb2 = new StringBuilder();
for (int i = sb.Length - 1; i >= 0; i--)
{
    sb2.Append(sb[i]);
}

if (multiplyer == 0)
{
    Console.WriteLine(0);
}
else
{
    Console.WriteLine(sb2.ToString());
}
