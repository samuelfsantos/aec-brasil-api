using System;
using System.Linq;
using Aec.Brasil.Domain.Entities;

namespace Aec.Brasil.Domain.Repositories
{
    public interface ICidadeRepository
    {
        IQueryable<Cidade> ObterComClimas();
        IQueryable<Cidade> ObterPorIdIntegracaoComClimas(int idIntegracao);
        Cidade ObterPorIdComClimas(Guid id);
    }
}
