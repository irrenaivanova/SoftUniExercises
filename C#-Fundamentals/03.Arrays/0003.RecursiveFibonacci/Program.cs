int n = int.Parse(Console.ReadLine());
int[] fibonachi = new int[n];
if (n > 2)
{
    for (int i = 2; i < n; i++)
    {
        int[] fibCurr = new int[i + 1];
        fibonachi[0] = 1;
        fibonachi[1] = 1;
        for (int j = 2; j < fibonachi.Length; j++)
        {
            fibCurr[0] = 1;
            fibCurr[1] = 1;
            fibCurr[j] = fibonachi[j - 1] + fibonachi[j - 2];
            fibonachi = fibCurr;
        }
    }
    Console.WriteLine(fibonachi[n - 1]);
}
else
    Console.WriteLine("1");
