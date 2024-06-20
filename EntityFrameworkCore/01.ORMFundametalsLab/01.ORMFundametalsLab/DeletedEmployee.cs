using System;
using System.Collections.Generic;

namespace _01.ORMFundametalsLab;

public partial class DeletedEmployee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public int DepartmentId { get; set; }

    public decimal Salary { get; set; }

    public virtual Department Department { get; set; } = null!;
}
