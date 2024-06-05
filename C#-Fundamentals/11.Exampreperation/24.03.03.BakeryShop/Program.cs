Dictionary<string, int> goods = new();
int total = 0;

while(true)
{
    string[] input = Console.ReadLine().Split();

    if (input[0]=="Complete")
    {
        break;
    }

    string command = input[0];
    int quantity = int.Parse(input[1]);
    string food = input[2];

    if (quantity<=0)
    {
        continue;
    }

    if (command == "Receive")
    {
        if (!goods.ContainsKey(food)) 
        {
            goods.Add(food, 0);
        }
        goods[food]+=quantity;
    }

    if (command=="Sell")
    {
        if (!goods.ContainsKey(food)) 
        {
            Console.WriteLine($"You do not have any {food}.");
            continue;
        }

        if (goods[food]<quantity)
        {
            total += goods[food];
            Console.WriteLine($"There aren't enough {food}. You sold the last {goods[food]} of them.");
            goods.Remove(food);
        }
        else
        {
            total += quantity;
            goods[food]-=quantity;
            if (goods[food]==0)
            {
                goods.Remove(food);
            }
            Console.WriteLine($"You sold {quantity} {food}.");
        }
    }
}
if (goods.Count > 0)
{
    Console.WriteLine(string.Join("\n", goods.Select(x => $"{x.Key}: {x.Value}")));
}
Console.WriteLine($"All sold: {total} goods");