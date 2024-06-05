//decimal number = decimal.Parse(Console.ReadLine());

//Console.WriteLine(number.ToString("0.##"));
//Console.WriteLine(number.ToString().TrimEnd('0', '.'));

SortedDictionary<string, Dictionary<string, decimal>> products = new SortedDictionary<string, Dictionary<string, decimal>>();

while (true)
{
    string command = Console.ReadLine();
    if (command == "Revision")
        break;

    string[] input = command.Split(", ");
    string shop = input[0];
    string product = input[1];
    decimal price = decimal.Parse(input[2]);

    if (!products.ContainsKey(shop))
    {
        products.Add(shop, new Dictionary<string, decimal>());
        products[shop].Add(product, price);
    }
    else if (!products[shop].ContainsKey(product))
    {
        products[shop].Add(product, price);
    }
}

foreach (var shop in products)
{
    Console.WriteLine($"{shop.Key}->");

    foreach (var item in shop.Value)
    {
        Console.WriteLine($"Product: {item.Key}, Price: {item.Value.ToString().TrimEnd('0', '.')}");
    }
}