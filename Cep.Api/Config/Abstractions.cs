using Cep.Api.Middleware;
using Cep.Infra.Data.Authorization;
using Cep.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cep.Api.Config
{
    public static class Abstractions
    {
        public static IServiceCollection AddAspNetUserConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var migrationAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<DefaultDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
