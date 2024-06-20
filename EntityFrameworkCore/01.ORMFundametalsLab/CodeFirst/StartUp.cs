using CodeFirst;

class StartUp
{
    static void Main(string[] args)
    {
        var db = new CodeFirstContext();
        db.Database.EnsureCreated();
    }
}