using majed_asp_mvc.Interfaces;
using majed_asp_mvc.Interfaces.IServices;
using majed_asp_mvc.Models;

namespace majed_asp_mvc.Serivces
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(User user)
        {
            _unitOfWork._repositoryUser.Add(user);
            _unitOfWork.Save();
        }

        public void Update(User user)
        {
            _unitOfWork._repositoryUser.Update(user);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork._repositoryUser.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork._repositoryUser.GetAll();
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return _unitOfWork._repositoryUser.GetAll().FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public User GetById(int id)
        {
            return _unitOfWork._repositoryUser.GetById(id);
        }

        public User? GetByUid(string uid)
        {
            return _unitOfWork._repositoryUser.GetByUId(uid);
        }


        public bool IsEmailExist(string email)
        {
            return _unitOfWork._repositoryUser.GetAll().Any(u => u.Email == email);
        }

    }
}
