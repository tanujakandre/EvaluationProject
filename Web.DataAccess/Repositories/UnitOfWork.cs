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

        public UnitOfWork(
            ApplicationDbContext db,
            ICategoryRepository categoryRepository,
            ITaskRepository taskRepository)
        {
            _db = db;
            Category = categoryRepository;
            Task = taskRepository;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
