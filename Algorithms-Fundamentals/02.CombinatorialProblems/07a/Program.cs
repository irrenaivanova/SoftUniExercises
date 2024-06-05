int n = int.Parse(Console.ReadLine());
int k = int.Parse(Console.ReadLine());


Console.WriteLine(Trinagle(n,k));

int Trinagle(int row,int col)
{
   if (row==0 || col==0 || col==row)
    {
        return 1;
    }
    return Trinagle(row-1, col) + Trinagle(row-1, col-1);
}