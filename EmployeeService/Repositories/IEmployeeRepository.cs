using EmployeeService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeService.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeesByGroupIdAsync(int groupId);
        //Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task SaveChangesAsync();
    }
}