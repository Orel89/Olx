using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OlxCore.Entities;
using OlxCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlxInfrastructure.Data
{
    public class SubcategoryRepository : GenericRepository<Subcategory>, ISubcategoryRepository
    {
        public SubcategoryRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {

        }
        public override async Task<IEnumerable<Subcategory>> AllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} AllAsync function error", typeof(SubcategoryRepository));
                return new List<Subcategory>();
            }
        }
        public override async Task<bool> UpdateAsync(Subcategory subcategory)
        {
            try
            {
                var existingSubcategory = await dbSet.Where(x => x.Id == subcategory.Id)
                                                    .FirstOrDefaultAsync();

                if (existingSubcategory == null)
                    return await AddAsync(subcategory);

                existingSubcategory = subcategory;


                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(SubcategoryRepository));
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
                _logger.LogError(ex, "{Repo} Delete function error", typeof(SubcategoryRepository));
                return false;
            }
        }
    }
}