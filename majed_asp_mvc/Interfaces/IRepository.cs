namespace majed_asp_mvc.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T GetByUId(string Uid);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(string uid);
    }
}
