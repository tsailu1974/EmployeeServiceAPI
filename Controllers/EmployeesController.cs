using Microsoft.AspNetCore.Mvc;
using EmployeeService.Models;
using EmployeeService.Services;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [Authorize]
        // GET: api/employees/5
        [HttpGet("group/{id}")] // Maps HTTP GET requests with an "id" parameter to this action
        public async Task<IActionResult> GetEmployeesByGroupId(int id)
        {
            var employees = await _employeeService.GetEmployeesByGroupIdAsync(id); // Calls the service to get employees by group ID

            return employees == null || !employees.Any() ? NotFound() : Ok(employees); // Returns 404 if no employees found, otherwise returns 200 with the employee list
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id); // Calls the service to get an employee by ID

            return employee == null ? NotFound() : Ok(employee); // Returns 404 if no employee found, otherwise returns 200 with the employee details
        }
       
    }
}