using System;
namespace DefiningClasses;

public class StartUp
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Family family = new Family();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            int age = int.Parse(input[1]);
            Person person = new Person(name,age);
            family.AddMembers(person);
           
        }
        //Person oldest = family.GetOldestMember();
        //Console.WriteLine($"{oldest.Name} {oldest.Age}");
       List<Person> list = family.GetMembers();

        foreach (var person in list)
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}
