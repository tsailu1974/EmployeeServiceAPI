using EmployeeService.Models;
using EmployeeService.DTO;

namespace EmployeeService.Services
{
    public interface IEmployeeService
    {
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<EmployeeDto>> GetEmployeesByGroupIdAsync(int id);
    }
}
