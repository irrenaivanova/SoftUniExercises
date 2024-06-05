int n = int.Parse(Console.ReadLine());
int k= int.Parse(Console.ReadLine());

int[] row= Trinagle(n);
Console.WriteLine(row[k]);

int[] Trinagle(int n)
{
    int[] row = new int[n+1];
    if (n==0)
    {
        return new int[1] {1};
    }
    if (n == 1)
    {
        return new int[2] { 1,1};
    }
    for (int i = 1; i < n; i++)
    {
        row[0] = 1;
        row[n] = 1;
        row[i] = Trinagle(n - 1)[i] + Trinagle(n - 1)[i-1];
    }
    return row;
}