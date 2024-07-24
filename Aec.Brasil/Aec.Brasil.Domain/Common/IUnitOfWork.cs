
namespace Aec.Brasil.Domain.Common
{

    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        Task<bool> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
