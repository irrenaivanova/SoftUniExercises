using _02.CreateAttribute;

[Author("Victor")]
class StartUp
{
    [Author("George")]
    [Author("Ivan")]
    [Author("Peter")]
    static void Main(string[] args)
    {
        var tracker = new Tracker();
        Console.WriteLine(tracker.PrintMethodsByAuthor());

    }
    [Author("Irenkaaaaaa")]
    public void Irenka()
    {

    }
}
