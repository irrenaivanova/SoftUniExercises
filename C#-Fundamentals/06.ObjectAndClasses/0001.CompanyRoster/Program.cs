using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

int n = int.Parse(Console.ReadLine());
List<Department> departments = new List<Department>();

for (int i = 0; i < n; i++)
{
    string[] employee = Console.ReadLine().Split();
    string name = employee[0];
    decimal salary = decimal.Parse(employee[1]);
    string department = employee[2];

    if (!departments.Select(x => x.NameDepartment).Contains(department))
    {
        Department newDepartment = new Department();
        newDepartment.NameDepartment = department;
        newDepartment.Employees.Add(new Employee(name, salary, department));
        departments.Add(newDepartment);
    }
    else
    {
        Department currentDepartment = departments.FirstOrDefault(x => x.NameDepartment == department);
        currentDepartment.Employees.Add(new Employee(name, salary, department));
    }
}

int numberOfDepartments = departments.Count();

decimal maxSalary = 0;
string maxSalaryDepartment = string.Empty;

foreach (var department in departments)
{
    decimal averageSalary = department.Employees.Select(x => x.Salary).Average();
    if (averageSalary > maxSalary)
    {
        maxSalary = averageSalary;
        maxSalaryDepartment = department.NameDepartment;
    }
}

Console.WriteLine(departments.FirstOrDefault(x => x.NameDepartment == maxSalaryDepartment));


class Department
{
    public List<Employee> Employees { get; set; } = new List<Employee>();
    public string NameDepartment { get; set; }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Highest Average Salary: {NameDepartment}");
        foreach (var employee in Employees.OrderByDescending(x => x.Salary))
        {
            sb.AppendLine($"{employee.Name} {employee.Salary:f2}");
        }
        return sb.ToString().TrimEnd('\n');
    }
}

class Employee
{
    public Employee(string name, decimal salary, string department)
    {
        Name = name;
        Salary = salary;
        Department = department;
    }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Department { get; set; }
}