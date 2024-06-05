string input = Console.ReadLine();

while(true)
{
    string[] command = Console.ReadLine().Split();

    if (command[0] == "End")
        break;

    if (command[0] == "Translate")
    {
        input = input.Replace(command[1], command[2]);
        Console.WriteLine(input);
    }

    if (command[0] == "Includes")
    {
        Console.WriteLine(input.Contains(command[1]));
    }

    if (command[0] == "Start")
    {
        Console.WriteLine(input.StartsWith(command[1]));
    }

    if (command[0] == "Lowercase")
    {
        input = input.ToLower();
        Console.WriteLine(input);
    }

    if (command[0] == "FindIndex")
    {
        char[] newStrng = input.ToCharArray();
        Array.Reverse(newStrng);
        string reverse = new string(newStrng);
        int index = reverse.IndexOf(command[1]);
        Console.WriteLine(input.Length-1-index);
    }

    if (command[0] == "Remove")
    {
        input = input.Remove(int.Parse(command[1]), int.Parse(command[2]));
        Console.WriteLine(input);
    }

}