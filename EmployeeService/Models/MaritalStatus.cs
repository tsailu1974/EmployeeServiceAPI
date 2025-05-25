using System;
using System.Collections.Generic;

namespace EmployeeService.Models;

public partial class MaritalStatus
{
    public byte MaritalStatusID { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
