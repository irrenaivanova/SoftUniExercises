HashSet<string> VIP = new HashSet<string>();
HashSet<string> regular = new HashSet<string>();

while (true)
{
    string input = Console.ReadLine();
    if (input == "PARTY")
        break;
    if (Char.IsDigit(input[0]))
    {
        VIP.Add(input);
    }
    else
    {
        regular.Add(input);
    }
}

while (true)
{
    string input = Console.ReadLine();
    if (input == "END")
        break;
    if (VIP.Contains(input))
    {
        VIP.Remove(input);
    }
    if (regular.Contains(input))
    {
        regular.Remove(input);
    }
}

Console.WriteLine(VIP.Count + regular.Count);
if (VIP.Count > 0)
    Console.WriteLine(string.Join("\n", VIP));
if (regular.Count > 0)
    Console.WriteLine(string.Join("\n", regular));