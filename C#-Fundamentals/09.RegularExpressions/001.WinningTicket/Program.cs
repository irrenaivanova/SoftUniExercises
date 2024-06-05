using System.Collections.Specialized;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

Regex regex = new Regex(@"\s*,\s*");
string[] tickets = regex.Split(Console.ReadLine());

for (int i = 0; i < tickets.Length; i++)
{
    Regex ifWin = new Regex(@"[@]{6,10}|[$]{6,10}|[#]{6,10}|[\^]{6,10}");
    if (tickets[i].Length != 20)
    {
        Console.WriteLine($"invalid ticket");
        continue;
    }
    string leftPart = tickets[i].Substring(0, 10);
    string rightPart = tickets[i].Substring(10);

    Match leftMatch = ifWin.Match(leftPart);
    Match rightMatch = ifWin.Match(rightPart);

    if (leftMatch.Success && rightMatch.Success)
    {
        if (leftMatch.Value == rightMatch.Value)
        {
            if (leftMatch.Value.Length == 10)
                Console.WriteLine($"ticket \"{tickets[i]}\" - {leftMatch.Value.Length}{leftMatch.Value[0]} Jackpot!");
            else
                Console.WriteLine($"ticket \"{tickets[i]}\" - {leftMatch.Value.Length}{leftMatch.Value[0]}");
        }
        else
        {
            if (leftMatch.Value[0] == rightMatch.Value[0])
            {
                int minCount = Math.Min(leftMatch.Value.Length, rightMatch.Value.Length);
                Console.WriteLine($"ticket \"{tickets[i]}\" - {minCount}{leftMatch.Value[0]}");
            }

            else
            { Console.WriteLine($"ticket \"{tickets[i]}\" - no match"); }
        }
    }
    else
    {
        Console.WriteLine($"ticket \"{tickets[i]}\" - no match");
    }
}