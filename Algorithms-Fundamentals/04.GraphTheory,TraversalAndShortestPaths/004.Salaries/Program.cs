int n = int.Parse(Console.ReadLine());
List<Employee> employees = new List<Employee>();

for (int i = 0; i < n; i++)
{
    Employee newEmployee = new Employee();
    newEmployee.Name = i;
    employees.Add(newEmployee);
}

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    for (int j = 0; j < input.Length; j++)
    {
        if (input[j]=='Y')
        {
            employees.FirstOrDefault(x => x.Name == i).Under.Add(employees.FirstOrDefault(x => x.Name == j));
        }
    }
}

foreach (var employee in employees)
{
    foreach (var under in employee.Under)
    {
        employees.FirstOrDefault(x => x.Name == under.Name).Managers.Add(new Employee() { Name=employee.Name});
    }
}

foreach (var employee in employees.Where(x => x.Under.Count <= 1))
{
    employee.Salary = 1;
}


while (true)
{
    if (employees.All(x=>x.Salary>0))
    {
        break;
    }
    employees = employees.OrderBy(x => x.Under.Count).ThenByDescending(x => x.Under.Sum(x => x.Salary)).ToList();
    employees.FirstOrDefault(x => x.Salary == 0).Salary = employees.FirstOrDefault(x => x.Salary == 0).Under.Sum(x => x.Salary);
}

Console.WriteLine(employees.Sum(x=>x.Salary));

class Employee
{
    public Employee()
    {
        Salary = 0;
    }

    public int Name { get; set; }
    public List<Employee> Under { get; set; } = new List<Employee>();
    public int Salary  { get; set; }
    public List<Employee> Managers { get; set; } = new List<Employee>();
}