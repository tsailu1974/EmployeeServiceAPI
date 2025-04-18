using Microsoft.AspNetCore.Mvc;
using EmployeeService.Models;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        // GET: api/employees/5
        [HttpGet("{id}")] // Maps HTTP GET requests with an "id" parameter to this action
        public IActionResult GetEmployeesByGroupId(int id)
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeId = 1,
                    GroupId = 101, 
                    FirstName = "Alice",
                    LastName = "Brown",
                    DateOfBirth = new DateTime(1990, 5, 20),
                    Gender = "F",
                    MaritalStatus = "Single",
                    EmploymentType = "Fulltime",
                    Email = "alice.brown@example.com",
                    HireDate = new DateTime(2021, 1, 15),
                    TerminationDate = null
                },
                new Employee
                {
                    EmployeeId = 2,
                    GroupId = 102,
                    FirstName = "Bob",
                    LastName = "Green",
                    DateOfBirth = new DateTime(1988, 11, 2),
                    Gender = "M",
                    MaritalStatus = "Married",
                    EmploymentType = "Contract",
                    Email = "bob.green@example.com",
                    HireDate = new DateTime(2022, 9, 10),
                    TerminationDate = new DateTime(2024, 4, 1)
                }
            };

            var employeesById = employees.FirstOrDefault(e => e.GroupId == id);

            if (employeesById == null)
            {
                return NotFound(); // Returns a 404 status code if the employee is not found
            }

            return Ok(employeesById);
        }
    }
}