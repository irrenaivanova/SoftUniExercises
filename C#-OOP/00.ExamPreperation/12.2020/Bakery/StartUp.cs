namespace Bakery
{
    using Bakery.Core;
    using Bakery.Models.BakedFoods;
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks;
    using Bakery.Models.Drinks.Contracts;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //List<IBakedFood> foods = new List<IBakedFood>();
            //foods.Add(new Cake("torta", 20.5m));
            //foods.Add(new Bread("hlqb", 2m));
            //Console.WriteLine(string.Join("\n", foods));
            //List<IDrink> drinks = new List<IDrink>();
            //drinks.Add(new Tea("4ai", 200, "anglijski"));
            //drinks.Add(new Water("woda", 100, "prqsna"));
            //Console.WriteLine(string.Join("\n", drinks));
            
            var engine = new Engine();

            engine.Run();
        }
    }
}
