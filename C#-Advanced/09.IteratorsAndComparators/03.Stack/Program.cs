using _03.Stack;

CostumStack list = new();

while(true)
{
    string[] input = Console.ReadLine().Split(new Char[2] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
    if (input[0] == "END")
        break;

    if (input[0] == "Push")
    {
        list.Push(input.Skip(1).Select(int.Parse).ToList());
    }

    if (input[0] =="Pop")
    {
        try
        {
            list.Pop();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}
for (int i = 0; i < 2; i++)
{
    foreach (var item in list)
    {
        Console.WriteLine(item);
    }
}
