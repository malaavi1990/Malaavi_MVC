using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalaaviMVC_DataLayer.Services;
using MalaaviMVC_DomainClasses.Products;

namespace MalaaviMVC_DataLayer.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetProductByCategoryId(int id);

    }
}
