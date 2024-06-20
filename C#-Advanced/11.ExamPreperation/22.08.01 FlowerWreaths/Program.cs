Stack<int> lilies = new(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Queue<int> roses = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
int wreaths = 0;
int storedFlowers = 0;

while(lilies.Count > 0  && roses.Count>0)
{
    int lily = lilies.Peek();
    int rose = roses.Peek();
    if (lily + rose<=15)
    {
        IfEqualOrLess(lily, rose);
    }
    while (lily + rose > 15)
    {
        lily -= 2;
        IfEqualOrLess(lily, rose);
    }
}

int newWreths = storedFlowers / 15;
wreaths += newWreths;

if (wreaths >= 5)
{
    Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
}
else
    Console.WriteLine($"You didn't make it, you need {5-wreaths} wreaths more!");


void IfEqualOrLess (int lily, int rose)
{
    if (lily + rose == 15)
    {
        lilies.Pop();
        roses.Dequeue();
        wreaths++;
    }

    if (lily + rose < 15)
    {
        lilies.Pop();
        roses.Dequeue();
        storedFlowers += lily + rose;
    }
}