string input = Console.ReadLine();
double sum = 0;

while (input != "Start")
{
    double coin = double.Parse(input);
    if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
        sum += coin;
    else
        Console.WriteLine($"Cannot accept {coin}");
    input = Console.ReadLine();
}

string input2 = Console.ReadLine();
while (input2 != "End")
{
    double price = 0;
    switch (input2)
    {
        case "Nuts": price = 2; break;
        case "Water": price = 0.7; break;
        case "Crisps": price = 1.5; break;
        case "Soda": price = 0.8; break;
        case "Coke": price = 1; break;

    }
    if (price == 0)
        Console.WriteLine("Invalid product");

    if (sum >= price && price != 0)
    {
        Console.WriteLine($"Purchased {input2.ToLower()}");
        sum -= price;
    }
    else if (sum < price && price != 0)
        Console.WriteLine($"Sorry, not enough money");
    input2 = Console.ReadLine();
}
Console.WriteLine($"Change: {sum:f2}");