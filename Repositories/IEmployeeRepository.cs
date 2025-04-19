using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeesByGroupIdAsync(int id);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    }
}