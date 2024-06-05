int row = int.Parse(Console.ReadLine());  
int col = int.Parse(Console.ReadLine());
Dictionary<Tuple<int,int>,long> binominal = new ();

Console.WriteLine(Binominal(row,col));
long Binominal(int row, int col)
{
    if (binominal.ContainsKey(Tuple.Create(row,col)))
    {
        return binominal[Tuple.Create(row, col)];
    }

    if (col == 0)
    {
        return 1;
    }

    if (row == col)
    {
        return 1;
    }

    long result = Binominal(row - 1, col) + Binominal(row - 1, col - 1);
    binominal.Add(new Tuple<int,int> (row, col), result);  
    return result;
}