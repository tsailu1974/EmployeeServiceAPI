namespace EmployeeService.DTO
{
    public class EmployeeDto
    {
        public int    EmployeeID     { get; set; }
        public string FirstName       { get; set; } = null!;
        public string LastName       { get; set; } = null!;
        public string Email          { get; set; } = null!;
        public string EmploymentType { get; set; } = null!;
    }
}