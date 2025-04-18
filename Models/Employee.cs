namespace EmployeeService.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int GroupId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string EmploymentType { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
    }    
}