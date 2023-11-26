using Microsoft.EntityFrameworkCore;

namespace ProductServices.Model
{
    public class ProductAppContext : DbContext
    {
        public ProductAppContext() { }
        public ProductAppContext(DbContextOptions<ProductAppContext> context) : base(context) { }

        public DbSet<ProductModel> Product { get; set; }
    }
}

