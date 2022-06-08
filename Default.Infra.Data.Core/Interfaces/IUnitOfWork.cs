using System;
using System.Threading;
using System.Threading.Tasks;

namespace Default.Infra.Data.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
