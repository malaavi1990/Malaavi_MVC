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
    public class ProductTagRepository:GenericRepository<ProductTag>,IProductTagRepository
    {
        private DataContext _context;
        private DbSet<ProductTag> _dbSet;
        public ProductTagRepository(DataContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<ProductTag>();
        }
    }
}
