using System.Collections.Generic;

Queue<string> kids = new Queue<string>(Console.ReadLine().Split());
int n = int.Parse(Console.ReadLine());
int toss = 1;
while (kids.Count > 1)
{
    if (toss == n)
    {
        Console.WriteLine($"Removed {kids.Dequeue()}");
        toss = 1;

    }
    if (toss != n)
    {
        string currKid = kids.Dequeue();
        kids.Enqueue(currKid);
        toss++;
    }
}
Console.WriteLine($"Last is {kids.Dequeue()}");