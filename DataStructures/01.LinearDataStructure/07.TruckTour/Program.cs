int n = int.Parse(Console.ReadLine());
Pump[] pumps = new Pump[n];

for (int i = 0; i < n; i++)
{
    int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();
    var pump = new Pump(values[0], values[1]);
    pumps[i] = pump;
}

int min = -1;

for (int i = 0; i < n; i++)
{
    bool notThis = false;
    int balance = 0;
    for (int j = i; j < i + n; j++)
    {
        int o = j;
        if (o >= n)
        {
            o -= n;
        }
        balance += (pumps[o].Oil - pumps[o].Distance);
        if (balance < 0)
        {
            notThis = true;
            break;
        }
    }
    if (notThis)
    {
        continue;
    }
    min = i;
    break;
}


Console.WriteLine(min);

public class Pump
{
    public Pump(int oil, int distance)
    {
        Oil = oil;
        Distance = distance;
    }

    public int Oil { get; set; }

    public int Distance { get; set; }
}
