
using Gifts.Models;

CompositeGift phone = new("Phone", 256);
phone.CalculateTotalPrice();
Console.WriteLine();

CompositeGift rootBox = new("RootBox", 0);
CompositeGift truckToy = new("Truck", 289);
CompositeGift plainToy = new("PlainToy", 587);

rootBox.Add(truckToy);
rootBox.Add(plainToy);

CompositeGift childBox = new("ChildBox", 0);
CompositeGift solderToy = new("SolderToy", 200);

childBox.Add(solderToy);
rootBox.Add(childBox);

Console.WriteLine($"Total price of this composite presents is: {rootBox.CalculateTotalPrice()}");