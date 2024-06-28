namespace SoftUni;

using System.Globalization;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Data;
using Models;
using Microsoft.VisualBasic;

public class StartUp
{
    static void Main(string[] args)
    {
        var db = new SoftUniContext();
        //string info3 = GetEmployeesFullInformation(db);
        //string info4 = GetEmployeesWithSalaryOver50000(db);
        //string info5 = GetEmployeesFromResearchAndDevelopment(db);
        //string info6 = AddNewAddressToEmployee(db);
        //string info7 = GetEmployeesInPeriod(db);
        //string info8 = GetAddressesByTown(db);
        //string info9 = GetEmployee147(db);
        //string info10 = GetDepartmentsWithMoreThan5Employees(db);
        //string info11 = GetLatestProjects(db);
        //string info12 = IncreaseSalaries(db);
        //string info13 = GetEmployeesByFirstNameStartingWithSa(db);
        //string info14 = DeleteProjectById(db);
        string info15 = RemoveTown(db);

        //PrintDepartmentsWithEmployeesMoreThan(db);

        Console.WriteLine(info15);

    }

    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        StringBuilder sb = new();
        foreach (var employee in context.Employees.OrderBy(x=>x.EmployeeId))
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
        }

        return sb.ToString().Trim();
    }

    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        StringBuilder sb = new();
        var employees = context.Employees.Where(x => x.Salary > 50000)
            .OrderBy(x=>x.FirstName)
            .Select(x => new { x.FirstName, x.Salary });
        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
        }

        return sb.ToString().Trim();
    }
    
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        StringBuilder sb = new();
        var employees = context.Employees
            .Where(x=>x.Department.Name=="Research and Development")
            .OrderBy(x=>x.Salary)
            .ThenByDescending(x=>x.FirstName)
            .Select(x=> new { x.FirstName,x.LastName,Department = x.Department.Name, x.Salary }).ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department} - ${e.Salary:f2}");
        }
        return sb.ToString().Trim();
    }
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        StringBuilder sb = new();
        Address newAddress = new Address() { AddressText = "Vitoshka 15", TownId = 4 };
        context.Addresses.Add(newAddress);
        var employee = context.Employees.Where(x => x.LastName == "Nakov").FirstOrDefault();
        employee.Address = newAddress;
        context.SaveChanges();
        var employees = context.Employees.OrderByDescending(x => x.AddressId).Take(10)
                .Select(x => new { Adress = x.Address.AddressText }).ToList();
        foreach (var e in employees)
        {
            sb.AppendLine(e.Adress);
        }
        return sb.ToString().Trim();
    } 

    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        StringBuilder sb = new();
        var employees = context.Employees
            //.Where(x=>x.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 &&
            //p.Project.StartDate.Year <= 2003))
            .Take(10)
            .Select(x=>new {x.EmployeeId, x.FirstName,x.LastName,ManagerFirst = x.Manager.FirstName,ManagerLast = x.Manager.LastName
                ,Projects= x.EmployeesProjects
                .Where(p => p.Project.StartDate.Year >= 2001 &&
                            p.Project.StartDate.Year <= 2003)
                .Select(y => new{NamePr = y.Project.Name,
                                StartDate = y.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                                EndDate = y.Project.EndDate.HasValue ?
                                y.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"})})
            .ToList();
  

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirst} {e.ManagerLast}");
            
            foreach (var p in e.Projects)
            {
                sb.AppendLine($"--{p.NamePr} - {p.StartDate} - {p.EndDate}");
            }

        }
        return sb.ToString().Trim();
    }

    public static string GetAddressesByTown(SoftUniContext context)
    {
        StringBuilder sb = new();
        var adressses = context.Employees
                .GroupBy(x => new { x.Address.AddressText, x.Address.Town.Name })
                .Select(x => new { x.Key.AddressText, x.Key.Name, EmployeeCount = x.Count() })
                .OrderByDescending(x => x.EmployeeCount)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .ToList();

        foreach (var adresss in adressses)
        {
            sb.AppendLine($"{adresss.AddressText}, {adresss.Name} - {adresss.EmployeeCount} employees");
        }

        return sb.ToString().Trim();
    }

    public static string GetEmployee147(SoftUniContext context)
    {
        StringBuilder sb = new();
        var employee = context.Employees
            .Where(x => x.EmployeeId == 147)
            .Select(x=>new { x.FirstName, x.LastName, x.JobTitle,
                Projects = x.EmployeesProjects.Select(y => y.Project.Name)})
            .FirstOrDefault();
        
        sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
        
        foreach (var pr in employee.Projects.OrderBy(x=>x))
        {
            sb.AppendLine(pr);
        }
        return sb.ToString().Trim();
    }

    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        StringBuilder sb = new();
        var departments = context.Departments.Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count())
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    ManF = x.Manager.FirstName,
                    ManL = x.Manager.LastName,
                    EmployeeDetails = x.Employees.OrderBy(x=>x.FirstName).ThenBy(x => x.LastName)  
                                    .Select(x => new { x.FirstName, x.LastName, x.JobTitle })
                })
                .ToList();

        foreach (var d in departments)
        {
            sb.AppendLine($"{d.Name} - {d.ManF} {d.ManL}");
            foreach (var emp in d.EmployeeDetails)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
            }
        }
        return sb.ToString().Trim();
    }


    //Кога имаме достъп до пропъртита и кога не ??
    public static void PrintDepartmentsWithEmployeesMoreThan(SoftUniContext context)
    {
        foreach (var department in context.Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count))
        {
            Console.WriteLine($"{department.Name} {department.Manager.FirstName}");
            foreach (var employee in department.Employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
            }
        }
    }

    public static string GetLatestProjects(SoftUniContext context)
    {
        StringBuilder sb = new();
        var projects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .OrderBy(x => x.Name)
                .Select(x => new { x.Name, x.Description,
                    StartDate = x.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)})
                .ToList();

        foreach (var pr in projects)
        {
            sb.AppendLine(pr.Name);
            sb.AppendLine(pr.Description);
            sb.AppendLine(pr.StartDate);
        }

        return sb.ToString().Trim();
    }

    public static string IncreaseSalaries(SoftUniContext context)
    {
        StringBuilder sb = new();
        List<string> departments = new List<string>() { "Engineering", "Tool Design", "Marketing", "Information Services" };
        var employees = context.Employees
            .Where(x => departments.Contains(x.Department.Name));
        
        foreach (var em in employees)
        {
            em.Salary += 0.12M*em.Salary;
        }
        context.SaveChanges();
        
        foreach (var em in employees.OrderBy(x=>x.FirstName).ThenBy(x=>x.LastName))
        {
            sb.AppendLine($"{em.FirstName} {em.LastName} (${em.Salary:f2})");
        }

        return sb.ToString().Trim();
    }

    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        StringBuilder sb = new();
        var employees = context.Employees.Where(x=>x.FirstName.StartsWith("Sa"))
            .OrderBy(x=>x.FirstName)
            .ThenBy(x=>x.LastName)
            .Select(x=>new {x.FirstName, x.LastName, x.JobTitle, x.Salary}).ToList();
        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
        }

        return sb.ToString().Trim();
    }

    public static string DeleteProjectById(SoftUniContext context)
    {

        var empPr = context.EmployeesProjects.Where(x => x.ProjectId == 2);
        foreach (var ep in empPr)
        {
            context.EmployeesProjects.Remove(ep);
        }
        var project = context.Projects.Find(2);
        context.Projects.Remove(project);
        context.SaveChanges();
        var projects = context.Projects.Take(10).ToList();

        return string.Join("\n", projects.Select(x=>x.Name));
    }

    public static string RemoveTown(SoftUniContext context)
    {
        var employees = context.Employees.Where(x => x.Address.Town.Name == "Seattle");
        foreach (var e in employees)
        {
            e.Address = null;
        }
        var adresses = context.Addresses.Where(x => x.Town.Name == "Seattle").ToList();
        context.Addresses.RemoveRange(adresses);
        var town = context.Towns.FirstOrDefault(x => x.Name == "Seattle");
        context.Towns.Remove(town);
        context.SaveChanges();
        return $"{adresses.Count()} addresses in Seattle were deleted";
    }
}