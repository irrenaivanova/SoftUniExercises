using _003.ShoppingSpree;

List<Person> persons = new();
List<Product> products = new();

string[] inputPerson =Console.ReadLine().Split(";");
string[] inputProduct = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);

foreach (var input in inputPerson)
{
    string[] tokens = input.Split("=");
	try
	{
		persons.Add(new Person(tokens[0], decimal.Parse(tokens[1])));
	}
	catch (Exception ex)
	{
        Console.WriteLine(ex.Message);
        return;
    }
}
foreach (var input in inputProduct)
{
    string[] tokens = input.Split("=");
    try
    {
        products.Add(new Product(tokens[0], decimal.Parse(tokens[1])));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
}
while (true)
{
    string[] buyTokens = Console.ReadLine().Split();
    if (buyTokens[0] == "END")
        break;
    persons.FirstOrDefault(x => x.Name == buyTokens[0])
        .Buying(products.First(x => x.Name == buyTokens[1]));
}
foreach (var person in persons)
{
    Console.WriteLine(person);
}
