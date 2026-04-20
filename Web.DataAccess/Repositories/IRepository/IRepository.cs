using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Web.Models.ViewModels;

namespace Web.DataAccess.Repositories.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter=null, string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter=null, string? includeProperties = null);
        T GetById(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void Remove(T entity);
        
    }
}
