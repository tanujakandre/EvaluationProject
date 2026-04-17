using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Web.DataAccess.Data;

namespace Web.DataAccess.Repositories.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        T GetById(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void Remove(T entity);
        
    }
}
