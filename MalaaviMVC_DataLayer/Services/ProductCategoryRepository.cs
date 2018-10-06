using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalaaviMVC_DataLayer.Context;
using MalaaviMVC_DataLayer.Repositories;
using MalaaviMVC_DomainClasses.Products;

namespace MalaaviMVC_DataLayer.Services
{
    public class ProductCategoryRepository:GenericRepository<ProductCategory>,IProductCategoryRepository
    {
        private DataContext _context;
        private DbSet<ProductCategory> _dbSet;
        public ProductCategoryRepository(DataContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<ProductCategory>();
        }

       
    }
}
