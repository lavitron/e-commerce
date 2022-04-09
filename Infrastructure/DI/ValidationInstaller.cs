using FluentValidation.AspNetCore;
using Infrastructure.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DI
{
    public static class ValidationInstaller
    {
        public static void AddFluentValidator(this IServiceCollection services)
        {
            var assembler = AppDomain.CurrentDomain.Load("Business");
            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssembly(assembler));

            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
        }
    }
}
