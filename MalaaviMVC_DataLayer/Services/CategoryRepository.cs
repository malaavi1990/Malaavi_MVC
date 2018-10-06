using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalaaviMVC_DataLayer.Context;
using MalaaviMVC_DataLayer.Repositories;
using MalaaviMVC_DomainClasses.Products;
using MalaaviMVC_DomainClasses.Users;

namespace MalaaviMVC_DataLayer.Services
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private DataContext _context;
        private DbSet<Category> _dbSet;
        public CategoryRepository(DataContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Category>();
        }


        public IEnumerable<Category> GetByParentId(int parentId)
        {
            return _dbSet.Where(c => c.ParentId == parentId).ToList();
        }
    }
}
