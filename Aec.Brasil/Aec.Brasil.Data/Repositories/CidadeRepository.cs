using Microsoft.EntityFrameworkCore;
using Aec.Brasil.Domain.Entities;
using Aec.Brasil.Domain.Repositories;
using System;
using System.Linq;

namespace Aec.Brasil.Data.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        protected readonly AecBrasilContext _context;

        public CidadeRepository(AecBrasilContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<Cidade> ObterPorIdIntegracaoComClimas(int idIntegracao)
        {
            var query = _context.Cidade.AsNoTracking()
                            .Include(x => x.Climas)
                            .Where(x => x.IdIntegracao == idIntegracao);

            return query;
        }

        public IQueryable<Cidade> ObterComClimas()
        {
            var query = _context.Cidade.AsNoTracking()
                            .Include(x => x.Climas);

            return query;
        }

        public Cidade ObterPorIdComClimas(Guid id)
        {
            var query = _context.Cidade.AsNoTracking()
                            .Include(x => x.Climas)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return query;
        }
    }
}
