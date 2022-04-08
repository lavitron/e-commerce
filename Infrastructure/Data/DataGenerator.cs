using DataAccess.Context;
using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ECommerceDbContext(serviceProvider.GetRequiredService<DbContextOptions<ECommerceDbContext>>()))
            {
                if (context.Carts.Any() || context.Products.Any())
                {
                    return;
                }
                context.Products.AddRange(
                    new Product
                    {
                        Id = 1,
                        Name = "Diş Fırçası",
                        CreatedDate = DateTime.Now,
                        CreatedUserId = 1,
                        IsDeleted = false,
                        Stock = 1000,
                        Description = "Yumuşak Uçlu Diş fırçası",
                    },
                    new Product
                    {
                        Id = 1,
                        Name = "Ütü",
                        CreatedDate = DateTime.Now,
                        CreatedUserId = 1,
                        IsDeleted = false,
                        Stock = 500,
                        Description = "Pamuklular için onaylı ütü",
                    });
            }
        }
    }
}
