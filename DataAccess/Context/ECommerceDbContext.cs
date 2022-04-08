using Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

        public DbSet<Cart>? Carts { get; set; }
        public DbSet<Product>? Products { get; set; }
    }
}
