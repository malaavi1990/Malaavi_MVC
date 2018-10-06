using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalaaviMVC_DataLayer.Context;
using MalaaviMVC_DataLayer.Repositories;
using MalaaviMVC_DomainClasses.Products;

namespace MalaaviMVC_DataLayer.Services
{
    public class ProductGalleryRepository:GenericRepository<ProductGallery>,IProductGalleryRepository
    {
        public ProductGalleryRepository(DataContext context) : base(context)
        {
        }
    }
}
