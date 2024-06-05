string str = Console.ReadLine();
int count = int.Parse(Console.ReadLine());
string RepeatString(string str, int count)
{
    string result = string.Empty;
    for (int i = 0; i < count; i++)
    {
        result += str;
    }
    return result;
}
Console.WriteLine(RepeatString(str, count));
