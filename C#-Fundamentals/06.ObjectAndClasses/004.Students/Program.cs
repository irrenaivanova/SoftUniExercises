using _004.Students;

int n = int.Parse(Console.ReadLine());

Student[] students = new Student[n];
for (int i = 0; i < n; i++)
{
    string[] student = Console.ReadLine().Split();
    float grade = float.Parse(student[2]);
    students[i] = new Student(student[0], student[1], grade);
}

//list = list.OrderByDescending(a=>a.Grade).ToArray();

for (int i = 0; i < students.Length; i++)
{
    int minIndex = i;
    for (int j = i; j < students.Length; j++)
    {
        if (students[j].Grade > students[minIndex].Grade)
            minIndex = j;
    }
    Student temp = students[minIndex];
    students[minIndex] = students[i];
    students[i] = temp;
}

for (int i = 0; i < students.Length; i++)
{
    Console.WriteLine(students[i]);
}



namespace _004.Students
{
    internal class Student
    {
        public Student(string firstName, string secondName, float grade)
        {
            FirstName = firstName;
            LastName = secondName;
            Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
}