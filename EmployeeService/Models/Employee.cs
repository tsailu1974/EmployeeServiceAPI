using System;
using System.Collections.Generic;

namespace EmployeeService.Models;

public partial class Employee
{
    public int EmployeeID { get; set; }

    public int? GroupID { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public byte? MaritalStatusID { get; set; }

    public byte? EmploymentTypeID { get; set; }

    public string? Email { get; set; }

    public DateTime? HireDate { get; set; }

    public DateTime? TerminateDate { get; set; }

    public virtual ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();

    public virtual EmploymentType? EmploymentType { get; set; }

    public virtual Group? Group { get; set; }

    public virtual MaritalStatus? MaritalStatus { get; set; }
}
