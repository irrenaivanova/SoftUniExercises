using System.Text;

string x = Console.ReadLine();
int y = int.Parse(Console.ReadLine());

StringBuilder sb = new StringBuilder();
int a = 0;
for (int i = x.Length - 1; i >= 0; i--)
{
    int multiply = ((int)x[i] - 48) * y + a;
    int b = 0;
    if (multiply > 9)
    {
        a = multiply / 10;
        b = multiply % 10;
    }
    else
    {
        b = multiply;
        a = 0;
    }
    string aa = a.ToString();
    string bb = b.ToString();

    if (i == 0)
    {
        sb.Append(bb);
        if (aa != "0")
        {
            sb.Append(aa);
        }
    }
    else
    {
        sb.Append(bb);
    }
}
StringBuilder reversed = new StringBuilder();
for (int i = sb.Length - 1; i >= 0; i--)
{
    reversed.Append(sb[i]);
}
bool isProductZero = true;
for (int i = 0; i < reversed.Length; i++)
{
    if (reversed[i] != '0')
    {
        isProductZero = false;
        break;
    }
    isProductZero = true;
}
if (!isProductZero)
    Console.WriteLine(reversed);
else
    Console.WriteLine("0");