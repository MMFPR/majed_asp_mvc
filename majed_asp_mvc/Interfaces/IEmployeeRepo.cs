using majed_asp_mvc.Models;

namespace majed_asp_mvc.Interfaces
{
    public interface IEmployeeRepo : IRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeesWithDepartmentAndJob();

    }
}
