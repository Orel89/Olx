using OlxCore.Interfaces.Repository;

namespace OlxCore.Interfaces.Configuration
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }

        Task<bool> SaveChangesAsync();

        bool SaveChanges();
    }
}
