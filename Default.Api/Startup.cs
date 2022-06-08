using Autofac;
using Autofac.Extensions.DependencyInjection;
using Default.Api.Config;
using Default.Api.Config.IoC;
using Default.Api.Config.Jwt;
using Default.Api.Core.Config;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace Default.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHealthChecks();
            services.AddControllers();
            services.AddSwaggerConfiguration();
            services.AddCors(o =>
            {
                o.AddPolicy("Everything", p => { p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
            });

            services.AddCustomDbContext(Configuration);

            services.AddJwtConfiguration(Configuration, "AppSettings");

            services.AddAspNetUserConfiguration();

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            services.AddAutoMapperConfiguration();

            services.AddDependencyInjectionConfiguration();

            services.AddMemoryCache();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new MediatorModule());
            builder.RegisterModule(new ApplicationModule());

            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfiguration();

            app.UseHealthChecks("/healthz");

            app.ConfigureCustomExceptionMiddleware();

            app.UseRouting();

            app.UseCors(o =>
            {
                o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);
        }
    }
}
