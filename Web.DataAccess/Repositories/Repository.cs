using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Web.DataAccess.Data;
using Web.DataAccess.Repositories.IRepository;

namespace Web.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;


        public IEnumerable<T> GetAll(Expression<Func<T, bool>>filter, string? includeProperties)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(prop);
                }
                query = query.Include(includeProperties);
            }
            return query.ToList();
        }
        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
            return query.FirstOrDefault();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);

        }

        
    }
}
