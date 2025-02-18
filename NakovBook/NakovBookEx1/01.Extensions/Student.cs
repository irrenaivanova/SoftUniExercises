namespace _01.Extensions
{
    public class Student
    {
        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int Age { get; set; }

        public Student[] StudentsWIthFirstNameLessThanLastNameComparer(Student[] list)
        {
            return list.Where(x => x.FirstName.CompareTo(x.LastName) < 0).ToArray();
        }

        public dynamic StudentsBetween18And24Finder(Student[] list)
        {
            return list.Where(x => x.Age >= 18 && x.Age <= 24).Select(x => new { x.FirstName, x.LastName });
        }


    }
}
