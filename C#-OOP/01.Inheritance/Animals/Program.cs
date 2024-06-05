
namespace Animals;
public class StartUp
{
    public static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();
        while(true)
        {
            string input  = Console.ReadLine();
            if (input == "Beast!")
                break;
            string[] input2 = Console.ReadLine().Split(); 
            
            if (input2.Count()!=3)
            {
                Console.WriteLine("Invalid input!"); 
            }
            
            try
            {
                switch (input)
                {
                    case "Cat": animals.Add(new Cat(input2[0], int.Parse(input2[1]), input2[2])); break;
                    case "Dog": animals.Add(new Dog(input2[0], int.Parse(input2[1]), input2[2])); break;
                    case "Frog": animals.Add(new Frog(input2[0], int.Parse(input2[1]), input2[2])); break;
                    case "Kitten": animals.Add(new Kitten(input2[0], int.Parse(input2[1]))); break;
                    case "Tomcat": animals.Add(new Tomcat(input2[0], int.Parse(input2[1]))); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        Console.WriteLine(string.Join("\n",animals));

    }
}
