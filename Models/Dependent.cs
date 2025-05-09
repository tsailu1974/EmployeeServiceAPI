using System;
using System.Collections.Generic;

namespace EmployeeService.Models;

public partial class Dependent
{
    public int DependentID { get; set; }

    public int? EmployeeID { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public byte? RelationshipTypeID { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual RelationshipType? RelationshipType { get; set; }
}
