using System.Security.Cryptography;
List<KeyValuePair<string,int>> peaks = new();
peaks.Add(new KeyValuePair<string, int>("Vihren", 80));
peaks.Add(new KeyValuePair<string, int>("Kutelo", 90));
peaks.Add(new KeyValuePair<string, int>("Banski Suhodol", 100));
peaks.Add(new KeyValuePair<string, int>("Polezhan", 60));
peaks.Add(new KeyValuePair<string, int>("Kamenitza", 70));

int peak = -1;
bool isFailed = false;

Stack<double> food = new(Console.ReadLine().Split(", ").Select(double.Parse));
Queue<double> stamina = new(Console.ReadLine().Split(", ").Select(double.Parse));

for (int i = 0; i < peaks.Count; i++)
{
    if (!food.Any() || !stamina.Any())
    {
        isFailed = true;
        Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
        break;
    }
  
    double currEnergy = food.Pop() + stamina.Dequeue();
    if (peaks[i].Value<=currEnergy)
    {
        peak++;
    }
    else
    {
        i--;
    }
}
if(!isFailed) 
{
    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
}
if (peak>-1)
{
    Console.WriteLine("Conquered peaks:");
    for (int i = 0; i <= peak; i++)
    {
        Console.WriteLine(peaks[i].Key);
    }
}
