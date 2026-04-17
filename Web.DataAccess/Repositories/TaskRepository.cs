using System;
using System.Collections.Generic;
using System.Text;
using Web.DataAccess.Data;
using Web.DataAccess.Repositories.IRepository;
using Web.Models;

namespace Web.DataAccess.Repositories
{
    public class TaskRepository : Repository<TaskManager>, ITaskRepository
    {
        public ApplicationDbContext _db;
        public TaskRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(TaskManager obj)
        {
            _db.Tasks.Update(obj);
        }

    }
}
