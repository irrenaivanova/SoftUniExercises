using _005.BirthdayCelebrations.Models;
using _006.FoodShortage.Models.Interfaces;

List<INameBuy> list = new List<INameBuy>();

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split();
    if (input.Length == 4)
    {
        list.Add(new Citizens(input[0], int.Parse(input[1]), input[2], input[3]));
    }
    else 
    {
        list.Add(new Rebel(input[0], int.Parse(input[1]), input[2]));
    }
}

while(true)
{
    string command= Console.ReadLine();
    if (command == "End")
        break;

    if (list.FirstOrDefault(x => x.Name == command) != null)
    {
        list.FirstOrDefault(x => x.Name == command).BuyFood();
    }
}

Console.WriteLine(list.Sum(x=>x.Food));