using Microsoft.EntityFrameworkCore;

namespace TokoServices.Model
{
    public class TokoAppContext : DbContext
    {
        public TokoAppContext() { }
        public TokoAppContext(DbContextOptions<TokoAppContext> context) : base(context) { }

        public DbSet<TokoModel> Toko { get; set; }
    }
}

