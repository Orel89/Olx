using System.Linq.Expressions;

namespace OlxCore.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> AllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> AddAsync(T entity);
        bool DeleteAsync(Guid id);
        bool UpdateAsync(T entity);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
