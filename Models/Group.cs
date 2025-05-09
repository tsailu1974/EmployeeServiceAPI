using System;
using System.Collections.Generic;

namespace EmployeeService.Models;

public partial class Group
{
    public int GroupID { get; set; }

    public string? GroupName { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public DateOnly? UpdatedDate { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
