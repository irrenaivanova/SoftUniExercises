int priceBullet = int.Parse(Console.ReadLine());
int sizeBarel = int.Parse(Console.ReadLine());
Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
int vallueIntelligence = int.Parse(Console.ReadLine());
int countTotalBullets = 0;
int count = 0;

while (locks.Count > 0)
{
    if (bullets.Count == 0)
    {
        Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        return;
    }
    if (bullets.Pop() <= locks.Peek())
    {
        locks.Dequeue();
        Console.WriteLine("Bang!");

    }
    else
    {
        Console.WriteLine("Ping!");
    }
    countTotalBullets++;
    count++;
    if (count == sizeBarel && bullets.Count > 0)
    {
        Console.WriteLine("Reloading!");
        count = 0;
    }
}
Console.WriteLine($"{bullets.Count} bullets left. Earned ${vallueIntelligence - countTotalBullets * priceBullet}");
