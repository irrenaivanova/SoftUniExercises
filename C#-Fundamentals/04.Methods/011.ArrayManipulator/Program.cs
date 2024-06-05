using System.Diagnostics.Metrics;

int[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
string command = Console.ReadLine();

while (command != "end")
{
    string[] commandWords = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);


    if (commandWords[0] == "exchange")
    {
        int splitIndex = int.Parse(commandWords[1]);
        if (splitIndex < 0 || splitIndex >= array.Length)
        {
            Console.WriteLine("Invalid index");
            command = Console.ReadLine();
            continue;
        }
        else
            array = ExchangeArray(array, splitIndex);
    }

    if (commandWords[0] == "max")
    {
        if (commandWords[1] == "even")
            MaxIndex(array, 0);
        else
            MaxIndex(array, 1);
    }

    if (commandWords[0] == "min")
    {
        if (commandWords[1] == "even")
            MinIndex(array, 0);
        else
            MinIndex(array, 1);
    }

    if (commandWords[0] == "first" || commandWords[0] == "last")
    {
        int countEl = int.Parse(commandWords[1]);
        string position = commandWords[0];

        if (countEl > array.Length)
        {
            Console.WriteLine("Invalid count");
            command = Console.ReadLine();
            continue;
        }

        if (commandWords[2] == "even")
            CountNumbers(array, countEl, 0, position);
        else
            CountNumbers(array, countEl, 1, position);
    }
    command = Console.ReadLine();
}


Console.WriteLine($"[{string.Join(", ", array)}]");

void MaxIndex(int[] array, int isOdd)
{
    int minValue = -1;
    int index = -1;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] >= minValue && array[i] % 2 == isOdd)
        {
            minValue = array[i];
            index = i;
        }
    }
    if (minValue == -1)
        Console.WriteLine("No matches");
    else
        Console.WriteLine(index);
}
void MinIndex(int[] array, int isOdd)
{
    int maxValue = int.MaxValue;
    int index = -1;
    bool isFound = false;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] <= maxValue && array[i] % 2 == isOdd)
        {
            maxValue = array[i];
            index = i;
            isFound = true;
        }
    }

    if (isFound)
        Console.WriteLine(index);
    else
        Console.WriteLine("No matches");
}


int[] ExchangeArray(int[] array, int splitIndex)
{
    int[] newarr = new int[array.Length];
    for (int i = 0; i < array.Length - splitIndex - 1; i++)
    {
        newarr[i] = array[splitIndex + i + 1];
    }
    for (int i = array.Length - splitIndex - 1; i < array.Length; i++)
    {
        newarr[i] = array[i - (array.Length - splitIndex - 1)];
    }
    return newarr;
}


void CountNumbers(int[] array, int countEl, int isOdd, string position)
{
    int count = 0;
    string newstr = String.Empty;
    if (position == "first")
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 == isOdd)
            {
                newstr += array[i] + " ";
                count++;
            }
            if (count == countEl)
                break;
        }
    }
    else if (position == "last")
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (array[i] % 2 == isOdd)
            {
                newstr += array[i] + " ";
                count++;
            }
            if (count == countEl)
                break;
        }

    int[] newarr = newstr.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    if (position == "last")
        Array.Reverse(newarr);
    Console.WriteLine($"[{string.Join(", ", newarr)}]");

}