using System;

int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
int count = 0;

while(count < 3)
{
    string[] command = Console.ReadLine().Split();
    if (command[0] == "Replace")
    {
        Replace(command[1], command[2]);
    }
    if (command[0] == "Print")
    {
        Print(command[1], command[2]);
    }
    if (command[0] == "Show")
    {
        Show(command[1]);
    }
}

Console.WriteLine(string.Join(", ",input));

void Replace(string index, string element)
{
    if (IsIndexValid(index) && IsElementValid(element))
    {
        input[int.Parse(index)] = int.Parse(element);
    }
}

void Print(string startIndex, string endIndex)
{
   if(IsIndexValid(startIndex) && IsIndexValid(endIndex))
    {
        List<int> output = new List<int>();
        for (int i = int.Parse(startIndex); i <= int.Parse(endIndex); i++)
        {
            output.Add(input[i]);
        }
        Console.WriteLine(string.Join(", ",output));
    }
}
void Show(string index)
{
   if (IsIndexValid(index))
    {
        Console.WriteLine(input[int.Parse(index)]);
    }
}
bool IsIndexValid(string index)
{
    try
    {
        int indexParse = int.Parse(index);
        if (indexParse < 0 || indexParse>=input.Length)
        {
            throw new ArgumentException("The index does not exist!");
        }
    }
    catch (FormatException)
    {
        count++;
        Console.WriteLine("The variable is not in the correct format!");
        return false;
    }
    catch (ArgumentException ex)
    {
        count++;
        Console.WriteLine(ex.Message);
        return false;
    }
    return true;
}
bool IsElementValid(string element)
{
    try
    {
        int indexParse = int.Parse(element);
    }
    catch (FormatException)
    {
        count++;
        Console.WriteLine("The variable is not in the correct format!");
        return false;
    }
    return true;
}