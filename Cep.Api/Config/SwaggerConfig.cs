using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Default.Api.Config
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
                    Description = "Busca Cep",
                    Contact = new OpenApiContact { Name = "Teste", Url = new Uri("https://teste.com.br/") }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Autorização JWT com o esquema Bearer no cabeçalho. \r\n\r\n Digite 'Bearer' [espaço] e o token que possui logo após.\r\n\r\nExemplo: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
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
