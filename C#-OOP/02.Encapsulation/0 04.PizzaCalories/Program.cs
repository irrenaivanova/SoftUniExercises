using _0_04.PizzaCalories;

string[] pizzaTokens = Console.ReadLine().Split();
Pizza pizza = new Pizza();
try
{
    pizza = new Pizza(pizzaTokens[1]);
    string[] tokensDough = Console.ReadLine().Split().Select(x => x.ToLower()).ToArray();
    Dough dough = new(tokensDough[1], tokensDough[2], double.Parse(tokensDough[3]));
    pizza.Dough = dough;
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}

while(true)
{
    string[] tokensTopping = Console.ReadLine().Split();
    if (tokensTopping[0] == "END")
        break;

    try
    { 
        Topping topping = new(tokensTopping[1], double.Parse(tokensTopping[2]));
        pizza.AddTopping(topping);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
    catch (SystemException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
}
Console.WriteLine(pizza);




