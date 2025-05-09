using System;
using System.Collections.Generic;

namespace EmployeeService.Models;

public partial class RelationshipType
{
    public byte RelationshipTypeID { get; set; }

    public string? RelationshipType1 { get; set; }

    public virtual ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();
}
