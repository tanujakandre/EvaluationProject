using System;
using System.Collections.Generic;
using System.Text;
using Web.DataAccess.Data;
using Web.DataAccess.Repositories.IRepository;

namespace Web.DataAccess.Repositories
{


    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public ICategoryRepository Category { get; }
        public ITaskRepository Task { get; }

        public UnitOfWork( ApplicationDbContext db   )     
        {
            _db = db;
            Category = new CategoryRepository(db);
            Task = new TaskRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
