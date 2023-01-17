using Cep.Domain.Core;
using Cep.Infra.Data.Context;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Cep.Infra.Data.Repository.Base.UnitOfWork
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, DefaultDbContext ctx, ILogger<UnitOfWork> logger)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<EntityBase>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            logger.LogTrace("DispatchDomainEventsAsync Domain Entities", domainEntities);

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            logger.LogTrace("DispatchDomainEventsAsync Domain Events", domainEvents);

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    logger.LogTrace("DispatchDomainEventsAsync Publish Domain Events", domainEvent);
                    await mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
