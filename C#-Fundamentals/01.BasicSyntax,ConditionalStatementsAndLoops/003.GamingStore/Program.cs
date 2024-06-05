double balance = double.Parse(Console.ReadLine());
string input = Console.ReadLine();
double price = 0;
double spent = 0;

while (input != "Game Time")
{
    if (input == "OutFall 4")
        price = 39.99;
    else if (input == "CS: OG")
        price = 15.99;
    else if (input == "Zplinter Zell")
        price = 19.99;
    else if (input == "Honored 2")
        price = 59.99;
    else if (input == "RoverWatch")
        price = 29.99;
    else if (input == "RoverWatch Origins Edition")
        price = 39.99;

    if (balance >= price && price != 0)
    {
        Console.WriteLine($"Bought {input}");
        balance -= price;
        spent += price;
    }
    else if (balance < price && price != 0)
        Console.WriteLine($"Too Expensive");
    else
        Console.WriteLine("Not Found");
    if (balance == 0)
        break;

    input = Console.ReadLine();
}
if (balance == 0)
    Console.WriteLine("Out of money!");
Console.WriteLine($"Total spent: ${spent:f2}. Remaining: ${balance:f2}");