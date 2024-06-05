
using PersonsInfo;
public class StartUp
{
    public static void Main(string[] args)
    {
        List<Person> persons = new List<Person>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            try
            {
                persons.Add(new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3])));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        decimal percentage = decimal.Parse(Console.ReadLine());
        persons.ForEach(x => x.IncreseSalary(percentage));
        persons.ForEach(x => Console.WriteLine(x));
    }
}
