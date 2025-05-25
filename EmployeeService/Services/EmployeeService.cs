using EmployeeService.Models;
using EmployeeService.Repositories;
using EmployeeService.DTO;

namespace EmployeeService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByGroupIdAsync(int id)
        {
            var employees = await _employeeRepository.GetEmployeesByGroupIdAsync(id);

            return employees.Select(static e => new EmployeeDto {
                    EmployeeID = e.EmployeeID,
                    FirstName = e.FirstName!,
                    LastName = e.LastName!,
                    Email = e.Email!,
                    EmploymentType = e.EmploymentType!.EmploymentType1!
            });
        }
      
    }
}