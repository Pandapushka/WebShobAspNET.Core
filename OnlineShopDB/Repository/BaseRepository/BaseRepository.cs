using Microsoft.EntityFrameworkCore;
using OnlineShopDB.Repository.BaseRepository;


namespace Core.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly DataBaseContext _context;
        protected readonly DbSet<T> _dbSet;

        protected BaseRepository(DataBaseContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
