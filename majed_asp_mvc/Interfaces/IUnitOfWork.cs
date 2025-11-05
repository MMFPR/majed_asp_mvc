using majed_asp_mvc.Models;

namespace majed_asp_mvc.Interfaces
{
    public interface IUnitOfWork
    {

        IEmployeeRepo _employeeRepo { get; }
        IRepository<Department> _departmentRepo { get; }
        IRepository<Job> _jobRepo { get; }
        IRepository<Nationality> _nationalityRepo { get; }
        IRepository<Category> _repositoryCategory { get; }
        IProductRepo _productRepo { get; }

        void Save();
    }
}

//private readonly IEmployeeRepo _employeeRepo;
//private readonly IRepository<Department> _departmentRepo;
//private readonly IRepository<Job> _jobRepo;
//private readonly IRepository<Nationality> _nationalityRepo;
