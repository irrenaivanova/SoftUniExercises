namespace CustomRandomList
{
    public class StartUp
    {
         static void Main(string[] args)
        {
         RandomList random = new RandomList();
            random.Add("1");
            random.Add("2");
            random.Add("3");
            random.Add("4");
            random.Add("5");
            random.Add("6");

            Console.WriteLine(random.RandomString());
        }

    }
}