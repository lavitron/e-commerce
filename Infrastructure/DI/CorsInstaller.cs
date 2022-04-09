using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DI
{
    public static class CorsInstaller
    {
        public static void AddCorsOption(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            });
        }
    }
}
