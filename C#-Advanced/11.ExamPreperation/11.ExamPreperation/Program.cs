using System.Collections.Generic;

List<int> coffeinList = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
List<int> drinksList = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
int coffeinDay = 0;

Stack<int> coffein = new Stack<int>();
Queue<int> drinks = new Queue<int>();

foreach (int coff in coffeinList)
{
    coffein.Push(coff);
}

foreach (int drink in drinksList)
{
    drinks.Enqueue(drink);
}

while(true)
{
    if (drinks.Count==0 || coffein.Count==0) 
        break;

    if (coffein.Peek()*drinks.Peek() + coffeinDay <=300)
    {
        coffeinDay += coffein.Pop() * drinks.Dequeue();
    }
    else
    {
        coffein.Pop();
        drinks.Enqueue(drinks.Dequeue());
        coffeinDay -= 30;
        if (coffeinDay<0)
        {
            coffeinDay = 0;
        }
    }
}

if (drinks.Count == 0)
{
    Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
    Console.WriteLine($"Stamat is going to sleep with {coffeinDay} mg caffeine.");
}
else
{
    Console.WriteLine($"Drinks left: {string.Join(", ",drinks)}");
    Console.WriteLine($"Stamat is going to sleep with {coffeinDay} mg caffeine.");
}



