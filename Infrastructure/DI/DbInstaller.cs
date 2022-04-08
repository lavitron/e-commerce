using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DI
{
    public static class DbInstaller
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddDbContextPool<ECommerceDbContext>(options => options.UseInMemoryDatabase(databaseName: "CommerceDb"),500);
        }
    }
}
