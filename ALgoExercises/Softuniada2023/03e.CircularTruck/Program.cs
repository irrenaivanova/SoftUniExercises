int n = int.Parse(Console.ReadLine());
Queue<Pumps> pumps = new Queue<Pumps>();
for (int i = 0; i < n; i++)
{
    int[] pumpsInput = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
    pumps.Enqueue(new Pumps(pumpsInput[0], pumpsInput[1], i));
}

int travelledPumps = 0;
int balance = 0;

while(travelledPumps < n)
{
    var currentPump = pumps.Dequeue();
    balance += currentPump.Oil - currentPump.Distance;
    pumps.Enqueue(currentPump);
    if (balance < 0)
    {
        travelledPumps = 0;
        balance = 0;
    }
    else
    {
        travelledPumps++;
    }
}

Console.WriteLine(pumps.Peek().Index);




public class Pumps
{
    public Pumps(int oil, int distance, int index)
    {
        Oil = oil;
        Distance = distance;
        Index = index;
    }

    public int Oil { get; set; }
    public int Distance { get; set; }

    public int Index { get; set; }
}