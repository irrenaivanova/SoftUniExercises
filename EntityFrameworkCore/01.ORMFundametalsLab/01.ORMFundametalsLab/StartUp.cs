

using _01.ORMFundametalsLab;

var db = new SoftUniContext();
var employees =  db.Employees.Where(x=>x.FirstName.StartsWith("A")).
    Select (x=>new {x.FirstName, DepartmentName = x.Department.Name}).ToList();

foreach (var employee in employees)
{
    Console.WriteLine($"{employee.FirstName} - {employee.DepartmentName})");
}