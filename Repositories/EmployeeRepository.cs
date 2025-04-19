using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new()
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
                HireDate = new DateTime(2021, 1, 15)
            },
            new Employee
            {
                EmployeeId = 2,
                GroupId = 101,
                FirstName = "Charlie",
                LastName = "Smith",
                DateOfBirth = new DateTime(1992, 3, 10),
                Gender = "M",
                MaritalStatus = "Single",
                EmploymentType = "Parttime",
                Email = "charlie.smith@example.com",
                HireDate = new DateTime(2023, 6, 10)
            },
            new Employee
            {
                EmployeeId = 3,
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

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await Task.FromResult(_employees.FirstOrDefault(e => e.EmployeeId == id));
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByGroupIdAsync(int id)
        {
            return await Task.FromResult(_employees.Where(e => e.GroupId == id));
        }
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await Task.FromResult(_employees);
        }
    }
}