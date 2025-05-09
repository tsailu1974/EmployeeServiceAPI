using System;
using System.Collections.Generic;

namespace EmployeeService.Models;

public partial class User
{
    public int UserID { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Role { get; set; }
}
