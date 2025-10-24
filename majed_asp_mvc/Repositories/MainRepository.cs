using majed_asp_mvc.Data;
using majed_asp_mvc.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace majed_asp_mvc.Repositories
{
    public class MainRepository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        public MainRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }

        public void Delete(string Uid)
        {
            var entity = _context.Set<T>().Find(Uid);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetByUId(string Uid)
        {
            return _context.Set<T>().SingleOrDefault(e => EF.Property<string>(e, "Uid") == Uid);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}