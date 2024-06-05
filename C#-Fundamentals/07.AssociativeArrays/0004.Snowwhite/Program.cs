List<Dwaft> dwafts = new List<Dwaft>();
List<HatColour> hats = new List<HatColour>();

while (true)
{
    string command = Console.ReadLine();
    if (command == "Once upon a time")
        break;
    string[] input = command.Split(" <:> ");
    string name = input[0];
    string colour = input[1];
    int physics = int.Parse(input[2]);

    if (!dwafts.Select(x => x.HatColour.Name).Contains(colour))
    {
        HatColour hatcolour = new HatColour();
        hatcolour.Name = colour;
        hatcolour.CountTimes = 1;
        dwafts.Add(new Dwaft(name, hatcolour, physics));
        hats.Add(hatcolour);
    }
    else
    {
        if (dwafts.Where(x => x.HatColour.Name == colour).Select(x => x.Colour).Contains(name))
        {
            if (dwafts.FirstOrDefault(x => x.Colour == name).Physics < physics)
            {
                dwafts.FirstOrDefault(x => x.Colour == name).Physics = physics;
            }
        }

        else
        {
            hats.FirstOrDefault(x => x.Name == colour).CountTimes++;
            HatColour hatColour = hats.FirstOrDefault(x => x.Name == colour);
            hatColour.CountTimes++;
            dwafts.Add(new Dwaft(name, hatColour, physics));
        }
    }
}


foreach (var item in dwafts.OrderByDescending(x => x.Physics).
    ThenByDescending(x => x.HatColour.CountTimes))
{
    Console.WriteLine(item);
}
class HatColour
{
    public string Name { get; set; }
    public int CountTimes { get; set; }
}
class Dwaft
{
    public Dwaft(string colour, HatColour hatcolour, int physics)
    {
        Colour = colour;
        HatColour = hatcolour;
        Physics = physics;
    }
    public string Colour { get; set; }
    public HatColour HatColour { get; set; }
    public int Physics { get; set; }
    public override string ToString()
    {
        return $"({HatColour.Name}) {Colour} <-> {Physics}";
    }
}