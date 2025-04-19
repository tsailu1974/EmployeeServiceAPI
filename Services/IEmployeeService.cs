using EmployeeService.Models;

namespace EmployeeService.Services
{
    public interface IEmployeeService
    {
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeesByGroupIdAsync(int id);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    }
}
