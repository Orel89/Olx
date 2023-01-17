using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OlxCore.Interfaces.Repository;
using System.Linq.Expressions;

namespace OlxInfrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext context;
        internal DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
            this._logger = logger;

        }

        public virtual Task<IEnumerable<T>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }
    }
    
}
