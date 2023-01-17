using Default.Infra.CrossCutting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Default.Api.Config
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(
                typeof(DomainToQueryDTOMappingProfile),
                typeof(DomainToDTOMappingProfile)
            );
        }
    }
}
