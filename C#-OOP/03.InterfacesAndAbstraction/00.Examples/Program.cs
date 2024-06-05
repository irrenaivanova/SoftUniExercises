using System;

class Program
{
    static void Main()
    {
        try
        {
            // Simulate an error
            int result = DivideByZero();
        }
        catch (Exception ex)
        {
            // Print the stack trace
            Console.WriteLine("Exception occurred:");
            Console.WriteLine(ex.StackTrace);
        }
    }

    static int DivideByZero()
    {
        // This will throw a DivideByZeroException
        int zero = 0;
        int result = 10 / zero ;
        return result;
    }
}
