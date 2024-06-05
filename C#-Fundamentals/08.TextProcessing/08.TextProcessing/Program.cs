while (true)
{
    string command = Console.ReadLine();
    if (command == "end")
        break;
    string newWord = string.Empty;
    for (int i = command.Length - 1; i >= 0; i--)
    {
        newWord += command[i];
    }
    Console.WriteLine($"{command} = {newWord}");
}