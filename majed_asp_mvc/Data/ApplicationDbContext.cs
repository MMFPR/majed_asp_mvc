
using majed_asp_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace majed_asp_mvc.Data
{



    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }

    }




}
