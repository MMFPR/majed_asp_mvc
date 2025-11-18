using majed_asp_mvc.Data;
using majed_asp_mvc.Interfaces;
using majed_asp_mvc.Models;

namespace majed_asp_mvc.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {

            //private readonly IEmployeeRepo _employeeRepo;
            //private readonly IRepository<Department> _departmentRepo;
            //private readonly IRepository<Job> _jobRepo;
            //private readonly IRepository<Nationality> _nationalityRepo;

            _context = context;
            _employeeRepo = new EmployeeRepo(_context);
            _departmentRepo = new MainRepository<Department>(_context);
            _jobRepo = new MainRepository<Job>(_context);
            _nationalityRepo = new MainRepository<Nationality>(_context);
            _repositoryCategory = new MainRepository<Category>(_context);
            _repositoryUser = new MainRepository<User>(_context);
            _productRepo = new ProductRepo(_context);

        }




        public IEmployeeRepo _employeeRepo { get; }
        public IRepository<Department> _departmentRepo { get; }
        public IRepository<Job> _jobRepo { get; }
        public IRepository<Nationality> _nationalityRepo { get; }
        public IRepository<Category> _repositoryCategory { get; }
        public IRepository<User> _repositoryUser { get; }
        public IProductRepo _productRepo { get; }
        public void Save()
        {
            _context.SaveChanges();
        }


    }
}
