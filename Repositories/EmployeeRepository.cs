using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.Data;
using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _db;

        public EmployeeRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _db.Employees
                            .FirstOrDefaultAsync(e => e.EmployeeID == id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByGroupIdAsync(int groupId)
        {
            return await _db.Employees
                            .Include(e => e.EmploymentType)
                            .Where(e => e.GroupID == groupId)
                            .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}