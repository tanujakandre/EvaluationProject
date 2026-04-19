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

        //IEnumerable<T> IRepository<T>.GetAll => throw new NotImplementedException();

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T Get(Expression<Func<T, bool>> filter)
        {
            return _dbSet.FirstOrDefault<T>(filter);
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
