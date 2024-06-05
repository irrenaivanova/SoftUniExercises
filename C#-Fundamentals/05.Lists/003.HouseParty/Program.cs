int n = int.Parse(Console.ReadLine());
List<string> list = new List<string>();

for (int i = 0; i < n; i++)
{
    List<string> command = Console.ReadLine().Split().ToList();
    if (command.Count == 3)
    {
        if (list.Count == 0)
        {
            list.Add(command[0]);
        }
        else
        {
            if (list.Contains(command[0]))
                Console.WriteLine($"{command[0]} is already in the list!");
            else
                list.Add(command[0]);
        }
    }
    if (command.Count == 4)
    {
        if (list.Count == 0)
        {
            Console.WriteLine($"{command[0]} is not in the list!");
        }
        else
        {

            if (list.Contains(command[0]))
                list.Remove(command[0]);
            else
                Console.WriteLine($"{command[0]} is not in the list!");
        }
    }
}
foreach (var item in list)
{
    Console.WriteLine(item);
}