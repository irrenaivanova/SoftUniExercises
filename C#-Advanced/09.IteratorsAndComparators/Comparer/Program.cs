List<Student> students = new List<Student>()
{
    new Student ("Dimi", 15),
    new Student("Ivan",6),
    new Student("Peter",2)
};

//students = students.OrderBy(x=>x.Age).ToList();

students.Sort(new StudentComparer());
foreach (var student in students)
{
    Console.WriteLine(student);
}

public class Student
{
    public Student(string name, int age) 
    { 
        Name = name;
        Age = age;
    }
    public string Name { get; set; }
    public int Age { get; set; }
    public override string ToString()
    {
        return $"{Name} - {Age}";
    }
}

class StudentComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        int result = x.Age.CompareTo(y.Age);
        
        if(result==0)
            result =  x.Name.CompareTo(y.Name);
        
        return result;
    }
}