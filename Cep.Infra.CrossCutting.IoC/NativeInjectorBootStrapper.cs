using Cep.Infra.Data.Core.Interfaces;
using Cep.Infra.Data.Repository.Base.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Cep.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
