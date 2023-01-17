using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OlxCore.Entities;
using OlxCore.Interfaces.Repository;

namespace OlxInfrastructure.Data
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<User>> AllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} AllAsync function error", typeof(UserRepository));
                return new List<User>();
            }
        }
        public override async Task<bool> UpdateAsync(User entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == entity.Id)
                                                    .FirstOrDefaultAsync();

                if (existingUser == null)
                    return await AddAsync(entity);

                existingUser.FirstName = entity.FirstName;
                existingUser.LastName = entity.LastName;
                existingUser.Email = entity.Email;
                existingUser.PhoneNumber = entity.PhoneNumber;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(UserRepository));
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
                _logger.LogError(ex, "{Repo} Delete function error", typeof(UserRepository));
                return false;
            }
        }
    }
}
