Queue<string> songs = new Queue<string> (Console.ReadLine().Split(", "));

while(songs.Any())
{
    string[] command = Console.ReadLine().Split(new[] {' '},2).ToArray();
    if (command[0] == "Play")
    {
        songs.Dequeue();
    }
    else if (command[0] == "Add")
    {
        if (songs.Contains(command[1]))
        {
            Console.WriteLine($"{command[1]} is already contained!");
            continue;
        }
        songs.Enqueue(command[1]);
    }
    else if (command[0] == "Show")
    {
        Console.WriteLine(string.Join(", ", songs));
    }
}
Console.WriteLine("No more songs!");