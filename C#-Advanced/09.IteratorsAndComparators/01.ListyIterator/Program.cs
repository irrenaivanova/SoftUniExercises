using _01.ListyIterator;

string[] input = Console.ReadLine().Split();

ListyIterator<string> list = new(input[1..]);

while(true)
{
    string command = Console.ReadLine();
    if (command == "END")
        break;

    if (command == "Move")
    {
        Console.WriteLine(list.Move());
    }
    if (command == "HasNext")
    {
        Console.WriteLine(list.HasNext());
    }
    if (command == "Print")
    {
        try
        {
            list.Print();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
    if (command == "PrintAll")
    {
        try
        {
            list.PrintAll();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
}