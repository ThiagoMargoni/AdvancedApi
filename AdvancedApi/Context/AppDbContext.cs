using AdvancedApi.Model;
using Microsoft.EntityFrameworkCore;

namespace AdvancedApi.Context
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public void SaveChanges() => base.SaveChanges();
    }
}
