using _007.OrderByAge;

List<Person> students = new List<Person>();

while (true)
{
    string command = Console.ReadLine();
    if (command == "End")
        break;

    string[] commandArg = command.Split();
    string name = commandArg[0];
    string id = commandArg[1];
    int age = int.Parse(commandArg[2]);
    students.Add(new Person(name, id, age));

    for (int i = 0; i < students.Count; i++)
    {
        if (students[i].Id == id)
        {
            students[i].Age = age;
            students[i].Name = name;
        }
    }
}
students = students.Distinct().ToList();

//list = list.OrderBy(x => x.Age).ToList();
for (int i = 0; i < students.Count; i++)
{
    int minIndex = i;

    for (int j = i; j < students.Count; j++)
    {
        if (students[j].Age < students[minIndex].Age)
            minIndex = j;
    }
    Person temp = students[minIndex];
    students[minIndex] = students[i];
    students[i] = temp;
}


for (int i = 0; i < students.Count; i++)
{
    Console.WriteLine(students[i]);
}
namespace _007.OrderByAge
{
    internal class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }
    }
}