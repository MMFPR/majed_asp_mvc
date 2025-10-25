using majed_asp_mvc.Data;
using majed_asp_mvc.Interfaces;
using majed_asp_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace majed_asp_mvc.Repositories
{
    public class ProductRepo : MainRepository<Product>, IProductRepo
    {

        private readonly ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProductsWithCategory()
        {
            return _context.Products.Include(c => c.Category).ToList();
        }
    }
}
