List<string> input = Console.ReadLine().Split().ToList();

while (true)
{
    string[] commandLine = Console.ReadLine().Split();
    string command = commandLine[0];
    if (command == "3:1")
        break;

    if (command == "merge")
    {
        int startIndex = int.Parse(commandLine[1]);
        int endIndex = int.Parse(commandLine[2]);
        if (startIndex < 0)
            startIndex = 0;
        if (endIndex >= input.Count)
            endIndex = input.Count - 1;

        int times = endIndex - startIndex;

        for (int i = 0; i < times; i++)
        {
            input[startIndex] += input[startIndex + 1];
            input.RemoveAt(startIndex + 1);
        }
    }
    if (command == "divide")
    {
        int index = int.Parse(commandLine[1]);
        int partitions = int.Parse(commandLine[2]);

        int parts = input[index].Length / partitions;

        int startChars = 0;
        int startInput = 1;
        for (int i = 0; i < partitions; i++)
        {
            string current = string.Empty;
            if (i == partitions - 1)
            {
                current = input[index].Substring(startChars);
            }
            else
            {
                for (int j = startChars; j < startChars + parts; j++)
                {
                    current += input[index][j];
                }
                startChars += parts;
            }
            input.Insert(index + startInput, current);
            startInput++;
        }
        input.RemoveAt(index);
    }
}

Console.WriteLine(string.Join(" ", input));

