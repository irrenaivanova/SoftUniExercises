string substring = Console.ReadLine();
string longString = Console.ReadLine();


while (true)
{
    int startIndex = longString.IndexOf(substring);
    if (startIndex == -1)
        break;
    longString = longString.Substring(0, startIndex) + longString.Substring(startIndex + substring.Length);
}

Console.WriteLine(longString);