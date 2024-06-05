Stack<int> money = new(Console.ReadLine().Split().Select(int.Parse));
Queue<int> food = new(Console.ReadLine().Split().Select(int.Parse));
int count = 0;

while(true)
{
    if (!money.Any() || !food.Any())
    {
        break;
    }
    if (money.Peek() > food.Peek())
    {
        count++;
        int adding = money.Pop()-food.Dequeue();
        if (money.Any())
        {
            money.Push(money.Pop() + adding);
        }  
    }
    else 
    {
        if (money.Pop() == food.Dequeue())
            count++;
    }
}

if (count == 0)
{
    Console.WriteLine("Henry remained hungry. He will try next weekend again.");
}
else if (count == 1)
{
    Console.WriteLine("Henry ate: 1 food.");
}
else if (count>1 && count<4)
{
    Console.WriteLine($"Henry ate: {count} foods.");
}
else
{
    Console.WriteLine($"Gluttony of the day! Henry ate {count} foods.");
}