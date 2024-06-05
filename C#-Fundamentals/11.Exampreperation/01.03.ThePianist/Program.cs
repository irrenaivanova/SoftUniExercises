int n = int.Parse(Console.ReadLine());
List<Piece> pieces = new();

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split("|");
    pieces.Add(new Piece(input[0], input[1], input[2]));
}

while(true)
{
    string[] command = Console.ReadLine().Split("|");
    if (command[0]=="Stop")
    {
        break;
    }

    if (command[0]=="Add")
    {
        if (pieces.FirstOrDefault(x => x.Name == command[1])!=null)
        {
            Console.WriteLine($"{command[1]} is already in the collection!");
        }
        else
        {
            pieces.Add(new Piece(command[1], command[2], command[3]));
            Console.WriteLine($"{command[1]} by {command[2]} in {command[3]} added to the collection!");
        }
    }

    if (command[0] == "Remove")
    {
        Piece curr = pieces.FirstOrDefault(x => x.Name == command[1]);
        if (curr==null)
        {
            Console.WriteLine($"Invalid operation! {command[1]} does not exist in the collection.");
        }
        else
        {
            pieces.Remove(curr);
            Console.WriteLine($"Successfully removed {command[1]}!");
        }
    }

    if (command[0] == "ChangeKey")
    {
        Piece curr = pieces.FirstOrDefault(x => x.Name == command[1]);
        if (curr == null)
        {
            Console.WriteLine($"Invalid operation! {command[1]} does not exist in the collection.");
        }
        else
        {
            curr.Key = command[2];
            Console.WriteLine($"Changed the key of {command[1]} to {command[2]}!");
        }
    }
}

if (pieces.Count > 0)
{
    Console.WriteLine(string.Join("\n",pieces.Select(x=>$"{x.Name} -> Composer: {x.Composer}, Key: {x.Key}")));
}


class Piece
{
    public Piece(string name, string composer, string key)
    {
        Name = name;
        Composer = composer;
        Key = key;
    }

    public string Name { get; set; }

    public string Composer { get; set; }

    public string Key { get; set; }

}