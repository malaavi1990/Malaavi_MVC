using MalaaviMVC_DataLayer.Configurations.ProductsConfiguration;
using MalaaviMVC_DataLayerConfigurations.UsersConfiguration;
using MalaaviMVC_DomainClasses.Products;
using MalaaviMVC_DomainClasses.Users;
using System.Data.Entity;


namespace MalaaviMVC_DataLayer.Context
{
    public class DataContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new RoleConfig());
            modelBuilder.Configurations.Add(new CategoryConfig());
            modelBuilder.Configurations.Add(new ProductCategoryConfig());
            modelBuilder.Configurations.Add(new ProductConfig());
            modelBuilder.Configurations.Add(new ProductGalleryConfig());
            modelBuilder.Configurations.Add(new ProductTagConfig());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductGallery> ProductGalleries { get; set; }
    }
}
