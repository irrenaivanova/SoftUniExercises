using _06.StoreBoxes;

string input = Console.ReadLine();
List<Box> boxes = new List<Box>();
while (input != "end")
{
    string[] splitted = input.Split();
    string serialNumber = splitted[0];
    string name = splitted[1];
    int quantity = int.Parse(splitted[2]);
    decimal price = decimal.Parse(splitted[3]);

    Item item = new Item();
    {
        item.Name = name;
        item.Price = price;
    }
    Box box = new Box();
    {
        box.Item = item;
        box.SerialNumber = serialNumber;
        box.ItemQuantity = quantity;
        box.PriceBox = item.Price * box.ItemQuantity;
    }
    boxes.Add(box);
    input = Console.ReadLine();
}
List<Box> boxesSort = boxes.OrderByDescending(a => a.PriceBox).ToList();
foreach (var box in boxesSort)
{
    Console.WriteLine(box.SerialNumber);
    Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
    Console.WriteLine($"-- ${box.PriceBox:f2}");
}

namespace _06.StoreBoxes
{
    internal class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PriceBox { get; set; }
    }
}
namespace _06.StoreBoxes
{
    internal class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

}