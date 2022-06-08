using Autofac;
using Default.Application.Commands.UsuarioModule.Command;
using Default.Application.Commands.UsuarioModule.Validations;
using Default.Domain.Repositories;
using Default.Infra.Data.Dapper;
using Default.Infra.Data.Repository;
using Default.Infra.Data.Repository.Base.UnitOfWork;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace Default.Api.Config.IoC
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

            builder.RegisterAssemblyTypes(typeof(UsuarioRepository).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(UsuarioQuery).GetTypeInfo().Assembly)
               .Where(t => t.Name.EndsWith("Query"))
               .AsImplementedInterfaces();
        }
    }
}
