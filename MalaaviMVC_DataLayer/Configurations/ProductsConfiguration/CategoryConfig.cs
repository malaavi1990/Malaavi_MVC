using MalaaviMVC_DomainClasses.Products;
using System.Data.Entity.ModelConfiguration;

namespace MalaaviMVC_DataLayer.Configurations.ProductsConfiguration
{
    class CategoryConfig:EntityTypeConfiguration<Category>
    {
        public CategoryConfig()
        {
            
        }
    }
}
