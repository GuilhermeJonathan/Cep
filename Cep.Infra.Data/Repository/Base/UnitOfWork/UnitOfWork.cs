using Cep.Infra.Data.Context;
using Cep.Infra.Data.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cep.Infra.Data.Repository.Base.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DefaultDbContext _context;
        private readonly IMediator _mediator;
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(DefaultDbContext context, IMediator mediator, ILogger<UnitOfWork> logger)
        {
            _context = context;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(_context, _logger);

            var result = await _context.SaveChangesAsync();
            _logger.LogTrace("Is CommitAsync DataBase Results", result);

        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
