List<Product> products = new List<Product>();

while (true)
{
    string productInfo = Console.ReadLine();

    if (productInfo == "buy")
        break;

    string[] productInfosplitted = productInfo.Split();
    string productName = productInfosplitted[0];
    double price = double.Parse(productInfosplitted[1]);
    int quantity = int.Parse(productInfosplitted[2]);

    if (!products.Select(x => x.Name).Contains(productName))
    {
        products.Add(new Product(productName, price, quantity));
    }
    else
    {
        Product currProduct = products.FirstOrDefault(x => x.Name == productName);
        currProduct.Quantity += quantity;
        currProduct.Price = price;
    }
}
foreach (var item in products)
{
    Console.WriteLine(item);
}
class Product
{
    public Product(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public override string ToString()
    {
        return $"{Name} -> {Quantity * Price:f2}";
    }
}