using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.TotalProductCount).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.UserId).IsRequired();
        }
    }
}