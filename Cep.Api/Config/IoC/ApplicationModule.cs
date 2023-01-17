using Autofac;
using Cep.Application.Commands.UsuarioModule.Command;
using Cep.Application.Commands.UsuarioModule.Validations;
using Cep.Application.Read.Queries.Estados;
using Cep.Domain.Repositories;
using Cep.Infra.Data.Dapper;
using Cep.Infra.Data.Repository;
using Cep.Infra.Data.Repository.Base.UnitOfWork;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace Cep.Api.Config.IoC
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>()
                .SingleInstance();

            builder.RegisterType<Notifier>().As<INotifier>().SingleInstance();

            builder.RegisterAssemblyTypes(typeof(Repository<>).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRepository<>))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(AutenticarUsuarioCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(AutenticarUsuarioCommandValidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(UsuarioQuery).GetTypeInfo().Assembly)
               .Where(t => t.Name.EndsWith("Query"))
               .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(GetEstadosQuery).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>))
            .AsImplementedInterfaces();
        }
    }
}
