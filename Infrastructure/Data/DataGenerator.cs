using DataAccess.Context;
using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    /// <summary>
    /// InMemory veritabanı için mock veritabanı verisi
    /// </summary>
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
                        Id = 2,
                        Name = "Ütü",
                        CreatedDate = DateTime.Now,
                        CreatedUserId = 4,
                        IsDeleted = false,
                        Stock = 500,
                        Description = "Pamuklular için onaylı ütü",
                    },
                      new Product
                      {
                          Id = 3,
                          Name = "Fırın",
                          CreatedDate = DateTime.Now,
                          CreatedUserId = 2,
                          IsDeleted = false,
                          Stock = 700,
                          Description = "Uzun ömürlü fırın",
                      });
                context.SaveChanges();
            }
        }
    }
}
