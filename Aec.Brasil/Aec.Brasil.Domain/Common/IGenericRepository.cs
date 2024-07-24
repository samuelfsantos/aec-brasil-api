using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Aec.Brasil.Domain.Common
{
    public interface IGenericRepository<T> where T : Entity
    {
        IQueryable<T> ObterTodos();
        IQueryable<T> Consultar(Expression<Func<T, bool>> predicate);
        Task<T> ObterAsync(Guid id);
        void Adicionar(T entity);
        void Modificar(T entity);
        void Remover(Guid id);
        void Remover(T entity);
    }
}
