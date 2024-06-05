using System.Text;
StringBuilder text = new StringBuilder();
int n = int.Parse(Console.ReadLine());
Stack<string[]> operations = new Stack<string[]>();

for (int i = 0; i < n; i++)
{
    string[] command = Console.ReadLine().Split();
    if (command[0] == "1")
    {
        text.Append(command[1]);
        operations.Push(new string[] { command[1], "add" });
    }
    else if (command[0] == "2")
    {
        int charsToRemove = int.Parse(command[1]);
        string substring = text.ToString().Substring(text.Length - charsToRemove);
        text.Remove(text.Length - charsToRemove, charsToRemove);
        operations.Push(new string[] { substring, "minus" });
    }
    else if (command[0] == "3")
    {
        int index = int.Parse(command[1]);
        Console.WriteLine(text[index - 1]);
    }
    else if (command[0] == "4")
    {
        string currAction = operations.Peek()[1];
        string currText = operations.Peek()[0];
        operations.Pop();
        if (currAction == "add")
        {
            int symbolsToSubstract = currText.Length;
            text.Remove(text.Length - symbolsToSubstract, symbolsToSubstract);
        }
        else if (currAction == "minus")
        {
            text.Append(currText);
        }
    }
}