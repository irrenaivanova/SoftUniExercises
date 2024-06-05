using _003.Telephony;
using System.Text.RegularExpressions;

string[] numbers = Console.ReadLine().Split();
string[] webs = Console.ReadLine().Split();
  

Smartphone smart = new();
StationaryPhone stationary = new StationaryPhone();

foreach (string number in numbers)
{
    if (!number.All(x=>char.IsDigit(x)))
    {
        Console.WriteLine("Invalid number!");
    }
    else if (number.Length==7)
    {
        stationary.Calling(number);
    }
    else
    {
        smart.Calling(number);
    }
}
foreach (var web in webs)
{
    smart.Browsing(web);
}