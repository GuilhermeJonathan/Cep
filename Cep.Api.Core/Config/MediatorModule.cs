using Autofac;
using Cep.Application.Core.Behaviors;
using Cep.Application.Core.Notification;
using MediatR;
using System.Reflection;

namespace Cep.Api.Core.Config
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { return componentContext.TryResolve(t, out object o) ? o : null; };
            });

            builder.RegisterType<NotificationDomainHandler>()
               .As<INotificationHandler<NotificationDomain>>()
               .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(ValidatorCommandBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
