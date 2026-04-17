using System;
using System.Collections.Generic;
using System.Text;
using Web.Models;

namespace Web.DataAccess.Repositories.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
    }
}
