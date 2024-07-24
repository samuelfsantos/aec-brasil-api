using Microsoft.EntityFrameworkCore;
using Aec.Brasil.Domain.Common;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Aec.Brasil.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected DbSet<T> _dbSet;

        protected readonly AecBrasilContext _context;

        public GenericRepository(AecBrasilContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<T>();
        }

        public virtual void Adicionar(T entity)
        {
            _dbSet.Add(entity).State = EntityState.Added;
        }

        public virtual IQueryable<T> Consultar(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }

        public virtual void Modificar(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual Task<T> ObterAsync(Guid id)
        {
            return _dbSet.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public virtual IQueryable<T> ObterTodos()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public virtual void Remover(Guid id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public virtual void Remover(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
