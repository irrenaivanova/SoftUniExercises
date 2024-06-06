HashSet<int> numbers  = new HashSet<int>();

while (numbers.Count < 10)
{
	try
	{
		int current = int.Parse(Console.ReadLine());
		ReadNumber(numbers, current);

	}
    catch (NotInRangeException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (FormatException)
	{
        Console.WriteLine("Invalid Number!");
    }
}

 void ReadNumber(HashSet<int> numbers,int current,int max = 100)
{
    int number = -1;
    if (numbers.Count == 0)
    {
        number = 1;
    }
    else
    {
        number = numbers.Last();
    }
    
    if (current<=number || current>=max)
    {
        throw new NotInRangeException(number);
    }
   numbers.Add(current);
}

Console.WriteLine(string.Join(", ",numbers));
public class NotInRangeException : Exception
{
    private const int MaxNumber = 100;
    public int Min;
    
    public NotInRangeException(int min)
    {
        Min = min;
    }
    public string Message => $"Your number is not in range {Min} - 100!";
}