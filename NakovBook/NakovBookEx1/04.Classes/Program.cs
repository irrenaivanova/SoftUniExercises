class CatManipulating
{
    static void Main()
    {
        Cat someCat = new Cat();
        someCat.SayMeow();
        Console.WriteLine("The color of cat {0} is {1}.",someCat.Name, someCat.Color);
        someCat = new Cat("Johnny", "brown");
        someCat.SayMeow();
        Console.WriteLine("The color of cat {0} is {1}.", someCat.Name, someCat.Color);
    }
}

public class Cat
{
    public Cat()
    {
    }

    public Cat(string name, string color)
    {
        Name = name;
        Color = color;
    }

    public string Name { get; set; }
    public string Color { get; set; }

    public void SayMeow()
    {
        Console.WriteLine("mm");
    }
}