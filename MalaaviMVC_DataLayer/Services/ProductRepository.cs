using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MalaaviMVC_DataLayer.Context;
using MalaaviMVC_DataLayer.Repositories;
using MalaaviMVC_DomainClasses.Products;
using MalaaviMVC_DomainClasses.Users;

namespace MalaaviMVC_DataLayer.Services
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private DataContext _context;
        private DbSet<Product> _dbSet;

        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Product>();
        }

        public IEnumerable<Product> GetProductByCategoryId(int id)
        {
            return _dbSet.Where(a => a.Id == id).ToList();
        }
    }
}
