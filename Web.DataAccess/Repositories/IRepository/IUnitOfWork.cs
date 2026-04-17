using System;
using System.Collections.Generic;
using System.Text;

namespace Web.DataAccess.Repositories.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category {  get; }
        ITaskRepository Task {  get; }

        public void Save();
    }
}
