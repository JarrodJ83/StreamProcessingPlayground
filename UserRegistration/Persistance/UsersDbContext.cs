using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using UserRegistration.Persistance.Model;

namespace UserRegistration.Persistance
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}