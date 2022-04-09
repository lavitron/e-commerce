using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Context
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Cart>? Carts { get; set; }
        public DbSet<Product>? Products { get; set; }
    }
}
