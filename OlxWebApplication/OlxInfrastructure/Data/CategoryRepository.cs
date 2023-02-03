using LS.Helpers.Hosting.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OlxCore.Entities;
using OlxCore.Interfaces.Repository;
using System.Threading;

namespace OlxInfrastructure.Data
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Category>> AllAsync()
        {
            try
            {
                return await dbSet
                    .Include(c => c.Subcategories)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} AllAsync function error", typeof(CategoryRepository));
                return new List<Category>();
            }
        }
        public override async Task<bool> UpdateAsync(Category entity)
        {
            try
            {
                var existingCategoty = await dbSet.Where(x => x.Id == entity.Id)
                                                    .FirstOrDefaultAsync();

                if (existingCategoty == null)
                    return await AddAsync(entity);

                existingCategoty.Name = entity.Name;


                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(CategoryRepository));
                return false;
            }
        }

        public override async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(CategoryRepository));
                return false;
            }
        }

        public Task<ExecutionResult<IEnumerable<Category>>> GetAllCategories()
        {
            throw new NotImplementedException();
        }
    }
}
