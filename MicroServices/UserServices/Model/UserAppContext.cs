using Microsoft.EntityFrameworkCore;

namespace UserServices.Model
{
    public class UserAppContext : DbContext
    {
        public UserAppContext() { }
        public UserAppContext(DbContextOptions<UserAppContext> context) : base(context) { }

        public DbSet<UserModel> Users { get; set; }
    }
}

