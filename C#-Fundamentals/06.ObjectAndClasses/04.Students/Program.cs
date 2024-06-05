using _04.Students;

string input = Console.ReadLine();
List<Student> students = new List<Student>();

while (input != "end")
{
    string[] splitted = input.Split();
    Student student = new Student();
    student.FirstName = splitted[0];
    student.LastName = splitted[1];
    student.Age = int.Parse(splitted[2]);
    student.HomeTown = splitted[3];
    students.Add(student);

    input = Console.ReadLine();
}

string criteriaTown = Console.ReadLine();
List<Student> studentsCriteriaTown = students.Where(x => x.HomeTown == criteriaTown).ToList();

foreach (Student student in studentsCriteriaTown)
{
    Console.WriteLine(student);
}

namespace _04.Students
{
    internal class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }

    }
}