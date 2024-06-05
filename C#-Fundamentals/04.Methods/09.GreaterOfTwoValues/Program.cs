string type = Console.ReadLine();

if (type == "char")
{
    char first = char.Parse(Console.ReadLine());
    char second = char.Parse(Console.ReadLine());
    Console.WriteLine(GetBigger2(first, second));
}
else if (type == "int")
{
    int first = int.Parse(Console.ReadLine());
    int second = int.Parse(Console.ReadLine());
    Console.WriteLine(GetBigger1(first, second));
}
else if (type == "string")
{
    string first = Console.ReadLine();
    string second = Console.ReadLine();
    Console.WriteLine(GetBigger(first, second));
}

string GetBigger(string a, string b)
{
    if (a.CompareTo(b) > 0)
        return a;
    else return b;
}
int GetBigger1(int a, int b)
{
    if (a > b)
        return a;
    else
        return b;
}

char GetBigger2(char a, char b)
{
    if (a > b)
        return a;
    else
        return b;
}

