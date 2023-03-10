using Microsoft.Extensions.Logging;
using OlxCore.Interfaces.Configuration;
using OlxCore.Interfaces.Repository;

namespace OlxInfrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public IUserRepository User { get; private set; }

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            User = new UserRepository(context, _logger);
        }
        public async Task<bool> SaveChangesAsync()
        {
            bool returnValue = true;
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    await dbContextTransaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "{UnitOfWork SaveChangesAsync function error", typeof(UnitOfWork));
                    returnValue = false;
                    await dbContextTransaction.RollbackAsync();
                }
            }

            return returnValue;
        }

        public bool SaveChanges()
        {
            bool returnValue = true;
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "{UnitOfWork SaveChangesAsync function error", typeof(UnitOfWork));
                    returnValue = false;
                    dbContextTransaction.Rollback();
                }
            }

            return returnValue;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
