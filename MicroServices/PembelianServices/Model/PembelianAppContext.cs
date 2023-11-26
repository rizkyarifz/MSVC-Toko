using Microsoft.EntityFrameworkCore;

namespace PembelianServices.Model
{
    public class PembelianAppContext : DbContext
    {
        public PembelianAppContext() { }
        public PembelianAppContext(DbContextOptions<PembelianAppContext> context) : base(context) { }

        public DbSet<PembelianModel> Pembelian { get; set; }
    }
}

