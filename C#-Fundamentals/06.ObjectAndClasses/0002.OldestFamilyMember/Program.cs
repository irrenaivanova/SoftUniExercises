int n = int.Parse(Console.ReadLine());
List<Person> persons = new List<Person>();
for (int i = 0; i < n; i++)
{
    string[] newPerson = Console.ReadLine().Split();
    string name = newPerson[0];
    int age = int.Parse(newPerson[1]);
    persons.Add(new Person(name, age));
}
int maxAge = 0;
string thePerson = string.Empty;

foreach (var person in persons)
{
    if (person.Age > maxAge)
    {
        maxAge = person.Age;
        thePerson = person.Name;
    }
}

Console.WriteLine($"{thePerson} {maxAge}");

class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public string Name { get; set; }
    public int Age { get; set; }
}