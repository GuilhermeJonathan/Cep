using Default.Infra.Data.Core.Interfaces;
using Default.Infra.Data.Repository.Base.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Default.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
