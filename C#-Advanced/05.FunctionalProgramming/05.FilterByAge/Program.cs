List<Person> people = ReadPeople();
string condition = Console.ReadLine();
int age  = int.Parse(Console.ReadLine());
string format = Console.ReadLine();

Predicate<Person> filter = CreateFilter(condition, age);
Action<Person> printer = CreatePrinter(format);
PrintFilteredPeople(people,filter,printer);

void PrintFilteredPeople(List<Person> people, Predicate<Person> filter, Action<Person> printer)
{
    foreach (Person person in people.Where(x => filter(x)))
    {
        printer(person);
    }
}

Action<Person> CreatePrinter(string format)
{
    switch(format)
    {
        case "name": return (x) => Console.WriteLine(x.Name);break;
        case "age": return (x) => Console.WriteLine(x.Age);break;
        case "name age": return (x) => Console.WriteLine($"{x.Name} - {x.Age}");break;
            default: return (x) => Console.WriteLine();
    }
}

Predicate<Person> CreateFilter(string condition, int age)
{
    if (condition=="younger")
    {
        return (x)=>(x.Age<age);
    }
    if (condition == "older")
    {
        return (x) => (x.Age >= age);
    }
    return null;
}

List<Person> ReadPeople()
{
    List<Person> list = new List<Person>();
    int n = int.Parse(Console.ReadLine());

    for (int i = 0; i < n; i++)
    {
        string[] input = Console.ReadLine().Split(", ").ToArray();
        list.Add(new Person(input[0], int.Parse(input[1])));
    }
    return list;
}

class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public string  Name { get; set; }
    public int Age { get; set; }    
}

