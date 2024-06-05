string[] input = Console.ReadLine().Split();

string text1 = input[0];
string text2 = input[1];

int minLength = Math.Min(text1.Length, text2.Length);
int sum = 0;
for (int i = 0; i < minLength; i++)
{
    sum += (int)(text1[i]) * (int)(text2[i]);
}
if (text1.Length > minLength)
{
    for (int i = minLength; i < text1.Length; i++)
    {
        sum += (int)text1[i];
    }
}
else
{
    for (int i = minLength; i < text2.Length; i++)
    {
        sum += (int)text2[i];
    }
}
Console.WriteLine(sum);
