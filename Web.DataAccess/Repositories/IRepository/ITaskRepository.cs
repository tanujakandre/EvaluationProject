using System;
using System.Collections.Generic;
using System.Text;
using Web.Models;

namespace Web.DataAccess.Repositories.IRepository
{
    public interface ITaskRepository : IRepository<TaskManager>
    {
        public void Update(TaskManager obj);
    }
}
