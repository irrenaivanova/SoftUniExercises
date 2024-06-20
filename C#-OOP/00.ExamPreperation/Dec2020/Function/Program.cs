int n = int.Parse(Console.ReadLine());
List<Person> persons = new List<Person>();  
for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(", ");
    persons.Add(new Person(input[0], int.Parse(input[1])));
}

string condAge = Console.ReadLine();
int age = int.Parse(Console.ReadLine());
string[] format = Console.ReadLine().Split();

string result = FormatCond(AgeCond(persons,condAge,age),format);
Console.WriteLine(result);


List<Person> AgeCond (IEnumerable<Person> persons,string condAge,int age)
{
    if (condAge == "younger")
    {
        return persons.Where(x => x.Age < age).ToList();
    }
    return persons.Where(x => x.Age >= age).ToList();
}

string FormatCond (IEnumerable<Person> persons, string[] format)
{
    if (format.Length==1)
    {
        if (format[0]=="name")
        {
            return string.Join("\n", persons.Select(x => x.Name));
        }
        if (format[0] == "age")
        {
            return string.Join("\n", persons.Select(x => x.Age));
        }
    }

    return string.Join("\n", persons.Select(x => $"{x.Name} - {x.Age}"));
}


public class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public int Age { get; set; }

}