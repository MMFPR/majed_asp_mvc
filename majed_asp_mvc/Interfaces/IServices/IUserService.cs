using majed_asp_mvc.Dtos;
using majed_asp_mvc.Models;

namespace majed_asp_mvc.Interfaces.IServices
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByUid(string uid);

        bool IsEmailExist(string email);
        void Create(User user);
        void Update(User user);
        void Delete(int id);

        User GetByEmailAndPassword(LoginRequestDto loginRequest);
    }
}
