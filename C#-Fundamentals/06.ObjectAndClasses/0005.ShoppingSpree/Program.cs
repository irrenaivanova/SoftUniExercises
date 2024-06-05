using System.Text;
using System.Xml.Linq;

List<Person> people = new List<Person>();
List<Product> products = new List<Product>();

string[] peopleInput = Console.ReadLine().Split(";");

for (int i = 0; i < peopleInput.Length; i++)
{
    string[] peopleInputSplitted = peopleInput[i].Split("=");
    people.Add(new Person(peopleInputSplitted[0], double.Parse(peopleInputSplitted[1])));
}

string[] productsInput = Console.ReadLine().Split(";");

for (int i = 0; i < productsInput.Length; i++)
{
    string[] productsInputSplitted = productsInput[i].Split("=");
    products.Add(new Product(productsInputSplitted[0], double.Parse(productsInputSplitted[1])));
}

while (true)
{
    string command = Console.ReadLine();

    if (command == "END")
        break;

    string[] commandSplitted = command.Split();
    string name = commandSplitted[0];
    string product = commandSplitted[1];

    Person currPerson = people.FirstOrDefault(x => x.Name == name);
    Product currProduct = products.FirstOrDefault(x => x.Name == product);

    if (currPerson.Money < currProduct.Price)
        Console.WriteLine($"{currPerson.Name} can't afford {currProduct.Name}");
    else
    {
        Console.WriteLine($"{currPerson.Name} bought {currProduct.Name}");
        currPerson.Purchases.Add(product);
        currPerson.Money -= currProduct.Price;
    }
}

foreach (var person in people)
{
    Console.WriteLine(person);
}

class Person
{
    public Person(string name, double money)
    {
        Name = name;
        Money = money;
    }
    public string Name { get; set; }
    public double Money { get; set; }
    public List<string> Purchases { get; set; } = new List<string>();
    public override string ToString()
    {
        if (Purchases.Count == 0)
            return $"{Name} - Nothing bought";
        else
            return $"{Name} - {string.Join(", ", Purchases)}";
    }
}
class Product
{
    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }
    public string Name { get; set; }
    public double Price { get; set; }
}