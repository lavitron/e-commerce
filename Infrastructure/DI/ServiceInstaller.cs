using Business.Abstract;
using Business.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DI;

public static class ServiceInstaller
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICartService, CartService>();
    }
}
