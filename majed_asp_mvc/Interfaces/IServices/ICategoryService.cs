using majed_asp_mvc.Models;

namespace majed_asp_mvc.Interfaces.IServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category? GetByUid(string uid);
        bool Create(Category category);
        bool Update(string uid, Category input);
        bool DeleteByUid(string uid);
    }
}
