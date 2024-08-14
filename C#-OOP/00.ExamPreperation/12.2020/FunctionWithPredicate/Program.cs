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

//var result = persons.Where()
Func <Person,bool> predicate;
if (condAge=="older")
{
    predicate = p=>p.Age>=age;
}
else
{
    predicate = p => p.Age < age;
}

var filteredPeople= persons.Where(predicate);

Action<Person> action;

if (format.Length == 1)
{
    action = Console.WriteLine("jkjfkd");

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