using System;

string[] input = Console.ReadLine().Split();
int sum = 0;

foreach (var element in input)
{
    try
    {
        sum += int.Parse(element);
	}
    catch (OverflowException)
    {
        Console.WriteLine($"The element '{element}' is out of range!");
    }
    catch (FormatException)
	{
        Console.WriteLine($"The element '{element}' is in wrong format!");
    }
    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
}
Console.WriteLine($"The total sum of all integers is: {sum}");