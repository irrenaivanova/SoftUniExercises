int n = int.Parse(Console.ReadLine());
try
{
    if (n<0)
    {
        throw new InvalidNumberException("Invalid number");
    }
    Console.WriteLine(Math.Sqrt(n));
  
}
catch (InvalidNumberException ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine("Goodbye.");

public class InvalidNumberException : Exception
{
    public InvalidNumberException(string? message) : base(message)
    {
    }
}