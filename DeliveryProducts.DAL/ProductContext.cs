using DeliveryProducts.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryProducts.DAL
{
    public class ProductContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        public ProductContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=ProductServices;Integrated Security=True");
        }
    }
}
