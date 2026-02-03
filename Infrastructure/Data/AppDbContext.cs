using Microsoft.EntityFrameworkCore;
using UserManagement.API.Domain.Entities;

namespace UserManagement.API.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
    }
}
