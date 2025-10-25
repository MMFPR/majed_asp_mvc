using majed_asp_mvc.Models;

namespace majed_asp_mvc.Interfaces
{
    public interface IProductRepo : IRepository<Product>
    {
        IEnumerable<Product> GetProductsWithCategory();

    }
}
