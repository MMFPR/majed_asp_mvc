using majed_asp_mvc.Data;
using majed_asp_mvc.Interfaces;
using majed_asp_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace majed_asp_mvc.Repositories
{
    public class EmployeeRepo : MainRepository<Employee>, IEmployeeRepo
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployeesWithDepartmentAndJob()
        {
            return _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Job)
                .ToList();
        }
    }
}
