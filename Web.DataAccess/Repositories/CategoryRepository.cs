using System;
using System.Collections.Generic;
using System.Text;
using Web.DataAccess.Data;
using Web.DataAccess.Repositories.IRepository;
using Web.Models;

namespace Web.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
