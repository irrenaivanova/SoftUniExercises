using System.Threading.Tasks.Dataflow;

int n = int.Parse(Console.ReadLine());
int[] passenger = new int[n];
int sum = 0;

for (int i = 0; i < n; i++)
{
    passenger[i] = int.Parse(Console.ReadLine());
    sum += passenger[i];
}
Console.WriteLine(string.Join(" ", passenger));
Console.WriteLine(sum);