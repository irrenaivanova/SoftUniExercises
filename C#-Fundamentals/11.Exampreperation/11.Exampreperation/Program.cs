using System.Data.SqlTypes;
using System.Runtime.InteropServices;

string userName = Console.ReadLine();

while (true)
{
    string[] command = Console.ReadLine().Split();

    if (command[0] == "Registration")
    {
        break;
    }

    if (command[0] == "Letters")
    {
        if (command[1] == "Lower")
        {
            userName = userName.ToLower();
            Console.WriteLine(userName);
        }
        else
        {
            userName = userName.ToUpper();
            Console.WriteLine(userName);
        }
    }

    if (command[0] == "Reverse")
    {
        int startInd = int.Parse(command[1]);
        int endInd = int.Parse(command[2]);

        if (startInd < 0 || startInd >= userName.Length || endInd >= userName.Length || endInd < startInd)
        {
            continue;
        }
        string subString = userName.Substring(startInd, endInd - startInd + 1);
        char[] sub = subString.ToCharArray();
        Array.Reverse(sub);
        Console.WriteLine(new string(sub));
    }

    if (command[0] == "Substring")
    {
        string sub = command[1];
        int index = userName.IndexOf(sub);
        if (index == -1)
        {
            Console.WriteLine($"The username {userName} doesn't contain {sub}.");
        }
        else
        {
            userName = userName.Remove(index, sub.Length);
            Console.WriteLine(userName);
        }
    }

    if (command[0] == "Replace")
    {
        char repl = char.Parse(command[1]);
        userName = userName.Replace(repl, '-');
        Console.WriteLine(userName);
    }

    if (command[0] == "IsValid")
    {
        char valid = char.Parse(command[1]);
        if (userName.Contains(valid))
        {
            Console.WriteLine("Valid username.");
            continue;
        }
        Console.WriteLine($"{valid} must be contained in your username.");
    }
}