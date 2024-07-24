using Microsoft.Extensions.Logging;
using Aec.Brasil.Domain.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Aec.Brasil.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AecBrasilContext _context;
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(AecBrasilContext context, ILogger<UnitOfWork> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Commit()
        {
            _logger.LogTrace("Executando Commit Database");
            var result = _context.SaveChanges();
            _logger.LogTrace("Resultado do Commit Database", result);
            return result > 0;
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogTrace("Executando CommitAsync Database");
            var result = await _context.SaveChangesAsync();
            _logger.LogTrace("Resultado do CommitAsync Database", result);
            return result > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
