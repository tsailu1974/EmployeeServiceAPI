using System;
using System.Collections.Generic;

namespace EmployeeService.Models;

public partial class EmploymentType
{
    public byte EmploymentTypeID { get; set; }

    public string? EmploymentType1 { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
