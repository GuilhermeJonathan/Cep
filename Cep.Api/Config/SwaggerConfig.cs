using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Cep.Api.Config
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            var xmlComentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlComentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlComentsFile);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Cep.Api",
                    Description = "Busca Cep Genérica"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                
            });

                c.IncludeXmlComments(xmlComentsFullPath, true);

            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
